using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
	float cellSize = 0.25f; //Size of our cells
	int numberOfColums, numberOfRows;
	public int spawnChancePercentage = 15;
	public GameCell[,] currentGen;
	public GameCell[,] nextGen;
	public void Start()
	{
		//Lower framerate makes it easier to test and see whats happening.
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 4;

		//Calculate our grid depending on size and cellSize
		numberOfColums = (int)Mathf.Floor(Width / cellSize);
		numberOfRows = (int)Mathf.Floor(Height / cellSize);

		//Initiate our matrix array
		currentGen = new GameCell[numberOfColums, numberOfRows];
		nextGen = new GameCell[numberOfColums, numberOfRows];
		//Create all objects

		//For each row
		for (int y = 0; y < numberOfRows; y++)
		{
			//for each column in each row
			for (int x = 0; x < numberOfColums; x++)
			{
				var gameCell = new GameCell(x * cellSize, y * cellSize, cellSize);
				//Create our game cell objects, multiply by cellSize for correct world placement
				currentGen[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);
				nextGen[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);

				//Random check to see if it should be alive
				if (Random.Range(0, 100) < spawnChancePercentage)
				{
					currentGen[x, y].alive = true;
				}
			}
		}
	}

	void CalcNextGen()
	{
		for (int x = 0; x < numberOfColums; x++)
		{
			for (int y = 0; y < numberOfRows; y++)
			{
				currentGen[x, y] = nextGen[x, y];
			}
		}
	}
	int CalcLiveNeighbours(int x, int y)
	{
		int liveNeighbours = 0;
        for (int i = -1; i <= 1; i++)
        {
			for (int j = -1; j <= 1; j++)
            {
				if (x + i < 0 || x + i >= numberOfColums) //OOB
					continue;
				if (y + j < 0 || y + j >= numberOfRows) //OOB
					continue;
				if (x + i == x && y + j == y) //Same cell
					continue;
				if (currentGen[x + i, y + j].alive)
					liveNeighbours++;
            }
        }
		return liveNeighbours;
	}
	void SpawnNextGen()
    {
        for (int x = 0; x < numberOfColums; x++)
        {
            for (int y = 0; y < numberOfRows;  y++)
            {
				int liveNeighbours = CalcLiveNeighbours(x, y);

				if (currentGen[x, y].alive == true && liveNeighbours < 2)
					nextGen[x, y].alive = false;
				else if (currentGen[x, y].alive == true && liveNeighbours > 3)
					nextGen[x, y].alive = false;
				else if (currentGen[x, y].alive == false && liveNeighbours == 3)
					nextGen[x, y].alive = true;
				else
					nextGen[x, y] = currentGen[x, y];
            }
        }
    }
	public void Update()
	{
		//Clear screen
		Background(0);
        //TODO: Calculate next generation
		CalcNextGen();
		//TODO: update buffer
		SpawnNextGen();
		//Draw all cells.
		for (int y = 0; y < numberOfRows; y++)
		{
			for (int x = 0; x < numberOfColums; x++)
			{
				//Draw current cell
				currentGen[x, y].Draw();
			}
		}
	}
}

//You will probably need to keep track of more things in this class
public class GameCell : ProcessingLite.GP21
{
    float x, y; //Keep track of our position
    float size; //our size

    //Keep track if we are alive
public bool alive = false;

//Constructor
public GameCell(float x, float y, float size)
{
    //Our X is equal to incoming X, and so forth
    //adjust our draw position so we are centered
    this.x = x + size / 2;
    this.y = y + size / 2;

    //diameter/radius draw size fix
    this.size = size / 2;
}

public void Draw()
{
    //If we are alive, draw our dot.
    if (alive)
    {
        //draw our dots
        Circle(x, y, size);
    }
}
}
