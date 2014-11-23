using System;

public class Game
{
	// Constants

	private const int sizeX = 10;
	private const int sizeY = 10;



	// Fields

	private bool[,] matrix = new bool[sizeX, sizeY];



	// Constructor

	public Game ()
	{
		this.GenerateRandomMatrix ();
	}



	// Methods

	public void GoNextState ()
	{
		bool[,] newMatrix = new bool[sizeX, sizeY];
		for (int x = 0; x < sizeX; x++)
			for (int y = 0; y < sizeY; y++)
				newMatrix[x, y] = this.GetNext (x, y);

		this.matrix = newMatrix;
	}

	public void Print ()
	{
		for (int x = 0; x < sizeX; x++)
		{
			for (int y = 0; y < sizeY; y++)
				Console.Write ("|{0}", this.matrix [x, y] ? "X" : " ");
			Console.WriteLine ("|");
		}
	}



	// Private methods

	private void GenerateRandomMatrix ()
	{
		var random = new Random ();
		for (int x = 0; x < sizeX; x++)
			for (int y = 0; y < sizeY; y++)
				this.matrix [x, y] = random.NextDouble () < 0.20;
	}

	private int GetLivingNeighbours (int x, int y)
	{
		return
			this.GetLivingValue (x - 1, y - 1) +
			this.GetLivingValue (x + 0, y - 1) +
			this.GetLivingValue (x + 1, y - 1) +
			this.GetLivingValue (x - 1, y) +
			this.GetLivingValue (x + 1, y) +
			this.GetLivingValue (x - 1, y + 1) +
			this.GetLivingValue (x + 0, y + 1) +
			this.GetLivingValue (x + 1, y + 1);
	}

	private int GetLivingValue (int x, int y)
	{
		if (x < 0 || x > sizeX - 1)
			return 0;
		if (y < 0 || y > sizeY - 1)
			return 0;

		return this.matrix [x, y] ? 1 : 0;
	}

	private bool GetNext (int x, int y)
	{
		var alive = this.matrix [x, y];
		var livingNeighbours = this.GetLivingNeighbours (x, y);

		// Any dead cell with exactly three live neighbours becomes a live cell
		if (!alive)
			return (livingNeighbours == 3);

		// Any live cell with less than two live neighbours dies
		// Any live cell with two or three live neighbours lives on to the next generation
		// Any live cell with more than three live neighbours dies
		return (livingNeighbours == 2 || livingNeighbours == 3);
	}
}
