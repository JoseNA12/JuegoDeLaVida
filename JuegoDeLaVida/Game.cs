using System;
using System.Linq;

public class Game
{
	// Fields

	private bool[] matrix;



	// Properties

	public int SizeX { get; private set; }
	public int SizeY { get; private set; }



	// Constructor

	public Game (int sizeX, int sizeY, double randomLimit)
	{
		this.SizeX = sizeX;
		this.SizeY = sizeY;
		this.GenerateRandomMatrix (randomLimit);
	}



	// Methods

	public bool GetValue (int x, int y)
	{
		return this.matrix [x + y * this.SizeX];
	}

	public void GoNextState ()
	{
		this.matrix = (
			from y in Enumerable.Range (0, this.SizeY)
			from x in Enumerable.Range (0, this.SizeX)
			let val = this.GetValue (x, y)
			let livingNeighbours = (
				from x2 in Enumerable.Range (x - 1, 3)
				from y2 in Enumerable.Range (y - 1, 3)
				where x2 >= 0 && x2 < this.SizeX
				where y2 >= 0 && y2 < this.SizeY
				where x2 != x || y2 != y
				where this.GetValue (x2, y2)
				select 1).Sum ()
			select ((val && (livingNeighbours == 2 || livingNeighbours == 3))
				|| (!val && livingNeighbours == 3)))
			.ToArray ();
	}



	// Private methods

	private void GenerateRandomMatrix (double randomLimit)
	{
		var random = new Random ();
		this.matrix = Enumerable.Range (1, this.SizeX * this.SizeY)
			.Select ((x) => random.NextDouble () <= randomLimit)
			.ToArray ();
	}
}
