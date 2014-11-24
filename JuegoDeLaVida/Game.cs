using System;
using System.Linq;

public class Game
{
	// Properties

	public bool[] Matrix { get; private set; }
	public int SizeX { get; private set; }
	public int SizeY { get; private set; }



	// Constructor

	public Game (int sizeX, int sizeY)
	{
		this.SizeX = sizeX;
		this.SizeY = sizeY;
		this.GenerateRandomMatrix ();
	}



	// Methods

	public void GoNextState ()
	{
		this.Matrix =
			(from x in this.Matrix.Select ((val, index) => new
			{
				val = val,
				column = index % this.SizeX,
				row = index / this.SizeX
			})
			let livingNeighbours = (from col in Enumerable.Range (x.column - 1, 3)
				from row in Enumerable.Range (x.row - 1, 3)
				where col >= 0 && col < this.SizeX
				where row >= 0 && row < this.SizeY
				where col != x.column || row != x.row
				where this.Matrix [col + row * this.SizeX]
				select 1).Sum ()
			select ((x.val && (livingNeighbours == 2 || livingNeighbours == 3))
				|| (!x.val && livingNeighbours == 3)))
			.ToArray ();
	}



	// Private methods

	private void GenerateRandomMatrix ()
	{
		var random = new Random ();
		this.Matrix = Enumerable.Range (1, SizeX * SizeY)
			.Select ((x) => random.NextDouble () < 0.20)
			.ToArray ();
	}
}
