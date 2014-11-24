using System;
using System.Threading;

class MainClass
{
	public static void Main ()
	{
		var g = new Game (40, 40, 0.4);
		while (true)
		{
			GameConsolePrinter.Print (g);
			Thread.Sleep (500);
			g.GoNextState ();
		}
	}
}
