using System;

class MainClass
{
	public static void Main ()
	{
		var g = new Game (10, 10);
		while (true)
		{
			GameConsolePrinter.Print (g);
			Console.WriteLine ("Enter para continuar. Q para salir.");
			if (Console.ReadLine () == "Q")
				break;

			g.GoNextState ();
		}
	}
}
