using System;

class MainClass
{
	public static void Main ()
	{
		var g = new Game ();
		while (true)
		{
			g.Print ();
			Console.WriteLine ("Enter para continuar. Q para salir.");
			if (Console.ReadLine () == "Q")
				break;

			g.GoNextState ();
		}
	}
}
