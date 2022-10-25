using UnityEngine;

class LucKar : IRandomWalker
{
	//Add your own variables here.
	private Vector2 currentPos = new Vector2(69, 69);
	private int startPosX = 69;
	private int startPosY = 69;
	private int _playAreaWidth;
	private int _playAreaHeight;


	//Do not use processing variables like width or height


	public string GetName()
	{
		return "LucKar"; //When asked, tell them our walkers name
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		//Select a starting position or use a random one.
		float x = startPosX;
		float y = startPosY;
		_playAreaHeight = playAreaHeight;
		_playAreaWidth = playAreaWidth;
		//a PVector holds floats but make sure its whole numbers that are returned!
		return new Vector2(x, y);
	}

	public Vector2 Movement()
	{
		//add your own walk behavior for your walker here.
		//Make sure to only use the outputs listed below.
		//if statements to not hit the borders (extra increment to not hit wallrunners early)
		if (currentPos.x < 5) //left border
		{
			currentPos.x += 1;
			return new Vector2(1, 0);
		}
		if (currentPos.x > _playAreaWidth - 5) //right border
        {
			currentPos.x -= 1;
			return new Vector2(-1, 0);
        }
		if (currentPos.y < 5) // bottom border
        {
			currentPos.y += 1;
			return new Vector2(0, 1);
        }

		if (currentPos.y > _playAreaHeight - 5) //top border
        {
			currentPos.y -= 1;
			return new Vector2(0, -1);
        }
        else
        {
			switch (Random.Range(0, 4)) //keep walking
			{
				case 0:
					currentPos.x -= 1;
					return new Vector2(-1, 0);
				case 1:
					currentPos.x += 1;
					return new Vector2(1, 0);
				case 2:
					currentPos.y += 1;
					return new Vector2(0, 1);
				default:
					currentPos.y -= 1;
					return new Vector2(0, -1);
			}
		}
	}
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!
