using System;
using OpenSilver.Simulator;

namespace OpenSilverApplication1.Simulator
{
	static class Startup
	{
		[STAThread]
		static int Main(string[] args)
		{
			return SimulatorLauncher.Start(typeof(App));
		}
	}
}
