#!/usr/bin/python3 
"""
A minimalist code for the Sofar 5-20KTL-3PH
With the home assistant, can save the purchased energy, especially in winter.
U need:

HA server supervised (https://github.com/home-assistant/supervised-installer)
with Solarman (https://github.com/StephanJoubert/home_assistant_solarman)

USB to RS485 connect to pin 1 and 4 in COM port (https://a.aliexpress.com/_mNrgQT8)

Kovik
Version 2023.01.18

based on:
Andre Wagner
https://www.facebook.com/groups/2477195449252168
Sofar Solar Inverter - Remote Control & Smart Home Integration
Version 2023.01.07
"""
import time
import minimalmodbus
import serial
import os
from datetime import datetime

check_file=r'/usr/share/hassio/homeassistant/sofar_auto.tmp'
stats = { 0: 'Waiting', 1: 'Detection', 2: 'Grid-connected', 3: 'Emergency power supply', 4: 'Recoverable fault', 5: 'Permanent fault', 6: 'Upgrade', 7: 'Self-charging'}

instrument = minimalmodbus.Instrument("/dev/ttyUSB0", 1)  # port name, slave address
instrument.serial.baudrate = 9600  # Baud
instrument.serial.bytesize = 8
instrument.serial.parity = serial.PARITY_NONE
instrument.serial.stopbits = 1
instrument.serial.timeout = 0.5  # seconds
instrument.mode = minimalmodbus.MODE_RTU
instrument.clear_buffers_before_each_transaction = True

def auto():
  print(f'{datetime.now().strftime("%d-%m-%Y %H:%M:%S")}: Start Inverter',flush=True)
  instrument.write_register(4356, 1)

def standby():
  print(f'{datetime.now().strftime("%d-%m-%Y %H:%M:%S")}: Shutdown Inverter',flush=True)
  instrument.write_register(4356, 0)

def ping():
  sofar_status = instrument.read_register(0x0404)
  return sofar_status

actual_status=open(check_file, 'r').read().strip()
wheel=0
while (True):
  try:
    switch_status=open(check_file, 'r').read().strip()
    if wheel % 10 == 0:
       inverter_status = ping()
       print(f'{datetime.now().strftime("%d-%m-%Y %H:%M:%S")}: Ping, inverter status: {stats[inverter_status]}, wheel: {wheel}, actual: {actual_status}, switch: {switch_status}',flush=True)

    if switch_status != actual_status:
      if switch_status=='ON':
        auto()
      elif switch_status == 'OFF':
        standby()

      actual_status=switch_status

    time.sleep(1)
    wheel+=1
  except Exception as e:
    print(e)
    pass

"""
HA configuration.yaml 

switch:
  - platform: command_line
    switches:
      sofar_auto:
        command_on: '/bin/echo ON > /config/sofar_auto.tmp'
        command_off: '/bin/echo OFF > /config/sofar_auto.tmp'
        command_state: 'if [ `cat /config/sofar_auto.tmp` == ON ] ; then true ; else  false ; fi'
        unique_id: 'sofar_auto'

HA automation switch ON (auto mode)
`````
alias: Sofar Auto Mode
description: ""
trigger:
  - platform: numeric_state
    entity_id: sensor.sofar_pv1_voltage
    above: 230
    for:
      hours: 0
      minutes: 5
      seconds: 0
condition:
  - condition: state
    entity_id: switch.sofar_auto
    state: "off"
    for:
      hours: 0
      minutes: 0
      seconds: 0
action:
  - service: switch.turn_on
    data: {}
    target:
      entity_id: switch.sofar_auto
mode: single
````

HA automation switch OFF (standby mode)
`````
alias: Sofar Standby Mode
description: ""
trigger:
  - platform: numeric_state
    entity_id: sensor.sofar_pv1_voltage
    below: 150
    for:
      hours: 0
      minutes: 5
      seconds: 0
condition:
  - condition: state
    entity_id: switch.sofar_auto
    state: "on"
    for:
      hours: 0
      minutes: 0
      seconds: 0
  - condition: numeric_state
    entity_id: sensor.sofar_battery_soc
    below: 30
action:
  - service: switch.turn_off
    data: {}
    target:
      entity_id: switch.sofar_auto
mode: single

"""

