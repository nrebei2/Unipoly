using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Stone : MonoBehaviour
{
	public GameObject ImageOfCard;
	public GameObject ImageOfCommunityChanceCard;
	public GameObject ImageOfChanceCard;

	// Use this for initialization
	void Start()
	{
		theStateManager = GameObject.FindObjectOfType<StateManager>();

		targetPosition = this.transform.position;

		spriteRenderer = ImageOfCard.GetComponent<Image>(); // we are accessing the Image that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = one; // set the sprite to the first sprite

		ChanceSpriteRenderer = ImageOfChanceCard.GetComponent<Image>(); // we are accessing the Image that is attached to the Gameobject
		if (ChanceSpriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			ChanceSpriteRenderer.sprite = Chance[0]; // set the sprite to sprite1
	}

	public Tile StartingTile;
	Tile currentTile;

	bool scoreMe = false;

	public float Player2Money = 1500f;

	StateManager theStateManager;

	Tile[] moveQueue;
	int moveQueueIndex;

	bool isAnimating = false;
	public bool inJail = false;

	public GameObject BuyCard2;
	public GameObject RentCard2;
	public GameObject CommunityChanceCard2;
	public GameObject ChanceCard2;

	Vector3 targetPosition;
	Vector3 velocity;
	float smoothTime = 0.15f;
	float smoothTimeVertical = 0.14f;
	float smoothDistance = 0.01f;
	float smoothHeight = 0.3f;


	// ALL SPRITES
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	public Sprite ten;
	public Sprite eleven;
	public Sprite twleve;
	public Sprite thirteen;
	public Sprite fourteen;
	public Sprite fifeteen;
	public Sprite sixteen;
	public Sprite seventeen;
	public Sprite eighteen;
	public Sprite nineteen;
	public Sprite twenty;
	public Sprite twentyone;
	public Sprite twentytwo;
	public Sprite twentythree;
	public Sprite twentyfour;
	public Sprite twentyfive;
	public Sprite twentysix;
	public Sprite twentyseven;
	public Sprite twentyeight;
	public Sprite twentynine;
	public Sprite thirty;
	public Sprite thirtyone;
	public Sprite thirtytwo;
	public Sprite thirtythree;
	public Sprite thirtyfour;
	public Sprite thirtyfive;
	public Sprite thirtysix;
	public Sprite thirtyseven;
	public Sprite thirtyeight;
	public Sprite thirtynine;
	public Sprite fourty;

	private Image spriteRenderer;
	private Image CommunitySpriteRenderer;
	private Image ChanceSpriteRenderer;

	// ALL COMMUNITY CHEST SPRITES
	public Sprite[] CommunityChance;

	// ALL CHANCE CHEST SPRITES
	public Sprite[] Chance;


	public bool Bought1 = false;
	public bool Bought2 = false;
	public bool Bought3 = false;
	public bool Bought4 = false;
	public bool Bought5 = false;
	public bool Bought6 = false;
	public bool Bought7 = false;
	public bool Bought8 = false;
	public bool Bought9 = false;
	public bool Bought10 = false;
	public bool Bought11 = false;
	public bool Bought12 = false;
	public bool Bought13 = false;
	public bool Bought14 = false;
	public bool Bought15 = false;
	public bool Bought16 = false;
	public bool Bought17 = false;
	public bool Bought18 = false;
	public bool Bought19 = false;
	public bool Bought20 = false;
	public bool Bought21 = false;
	public bool Bought22 = false;
	public bool Bought23 = false;
	public bool Bought24 = false;
	public bool Bought25 = false;
	public bool Bought26 = false;
	public bool Bought27 = false;
	public bool Bought28 = false;

	public PlayerStone Player1;

	public GameObject Player1Win;

	// Update is called once per frame
	void Update()
	{

		if (Player2Money <= 0f)
		{
			Player2Money = 0f;
			Player1Win.SetActive(true);
		}

		if (theStateManager.CurrentPlayerId == 1)
		{
			if (isAnimating == false)
			{
				// Nothing for us to do.
				return;
			}

			if (Vector3.Distance(
				   new Vector3(this.transform.position.x, targetPosition.y, this.transform.position.z),
				   targetPosition) < smoothDistance)
			{
				// We've reached the target. How's our height?
				if (moveQueue != null && moveQueueIndex == (moveQueue.Length) && this.transform.position.y > smoothDistance)
				{
					this.transform.position = Vector3.SmoothDamp(
						this.transform.position,
						new Vector3(this.transform.position.x, 0, this.transform.position.z),
						ref velocity,
						smoothTimeVertical);
				}
				else
				{
					// Right position, right height -- let's advance the queue
					AdvanceMoveQueue();
				}
			}
			else if (this.transform.position.y < (smoothHeight - smoothDistance))
			{
				// We want to rise up before we move sideways.
				this.transform.position = Vector3.SmoothDamp(
					this.transform.position,
					new Vector3(this.transform.position.x, smoothHeight, this.transform.position.z),
					ref velocity,
					smoothTimeVertical);
			}
			else
			{
				this.transform.position = Vector3.SmoothDamp(
					this.transform.position,
					new Vector3(targetPosition.x, smoothHeight, targetPosition.z),
					ref velocity,
					smoothTime);
			}
		} else
		{
			return;
		}

		// Reset position

		if (theStateManager.numberOfTilesPlayer2 == 41)
		{
			theStateManager.numberOfTilesPlayer2 = 1;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 42)
		{
			theStateManager.numberOfTilesPlayer2 = 2;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 43)
		{
			theStateManager.numberOfTilesPlayer2 = 3;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 44)
		{
			theStateManager.numberOfTilesPlayer2 = 4;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 45)
		{
			theStateManager.numberOfTilesPlayer2 = 5;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 46)
		{
			theStateManager.numberOfTilesPlayer2 = 6;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 47)
		{
			theStateManager.numberOfTilesPlayer2 = 7;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 48)
		{
			theStateManager.numberOfTilesPlayer2 = 8;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 49)
		{
			theStateManager.numberOfTilesPlayer2 = 9;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 50)
		{
			theStateManager.numberOfTilesPlayer2 = 10;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 51)
		{
			theStateManager.numberOfTilesPlayer2 = 11;
			Player2Money += 200f;
		}
		if (theStateManager.numberOfTilesPlayer2 == 52)
		{
			theStateManager.numberOfTilesPlayer2 = 12;
			Player2Money += 200f;
		}

	}

	void AdvanceMoveQueue()
	{
		if (theStateManager.CurrentPlayerId == 0)
		{
			return;
		}
		if (moveQueue != null && moveQueueIndex < moveQueue.Length)
		{
			Tile nextTile = moveQueue[moveQueueIndex];
			if (nextTile == null)
			{
				// We are probably being scored
				// TODO: Move us to the scored pile
				SetNewTargetPosition(this.transform.position + Vector3.right * 10f);
			}
			else
			{
				SetNewTargetPosition(nextTile.transform.position);
				moveQueueIndex++;
			}
		}
		else
		{
			// The movement queue is empty, so we are done animating!
			theStateManager.numberOfTilesPlayer2 += theStateManager.DiceTotal;
			Debug.Log("Done animating!");
			this.isAnimating = false;
			theStateManager.IsDoneAnimating = true;
			// TODO: ADD UI


			// WHAT TO DO IF THE PLAYER IS ON THE TILE, LOTS OF CODE HERE BOIZ

			if (theStateManager.numberOfTilesPlayer2 == 1)
			{
				spriteRenderer.sprite = one;
			}
			if (theStateManager.numberOfTilesPlayer2 == 2)
			{
				spriteRenderer.sprite = two;
				if (Bought1 == true) 
{
 return;
}
else if (Player1.Bought1 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 60f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 3)
			{
				spriteRenderer.sprite = three;
				CommunityChanceCard2.SetActive(true);
			}
			if (theStateManager.numberOfTilesPlayer2 == 4)
			{
				spriteRenderer.sprite = four;
				if (Bought2 == true) 
{
 return;
}
else if (Player1.Bought2 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 60f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 5)
			{
				spriteRenderer.sprite = five;
				Player2Money -= 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 6)
			{
				spriteRenderer.sprite = six;
				if (Bought3 == true) 
{
 return;
}
else if (Player1.Bought3 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 7)
			{
				spriteRenderer.sprite = seven;
				if (Bought4 == true) 
{
 return;
}
else if (Player1.Bought4 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 100f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 8)
			{
				spriteRenderer.sprite = eight;
				ChanceCard2.SetActive(true);
			}
			if (theStateManager.numberOfTilesPlayer2 == 9)
			{
				spriteRenderer.sprite = nine;
				if (Bought5 == true) 
{
 return;
}
else if (Player1.Bought5 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 100f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 10)
			{
				spriteRenderer.sprite = ten;
				if (Bought6 == true) 
{
 return;
}
else if (Player1.Bought6 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 120f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 11)
			{
				inJail = true;
				spriteRenderer.sprite = eleven;
			}
			if (theStateManager.numberOfTilesPlayer2 == 12)
			{
				spriteRenderer.sprite = twleve;
				if (Bought7 == true) 
{
 return;
}
else if (Player1.Bought7 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 140f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 13)
			{
				spriteRenderer.sprite = thirteen;
				if (Bought8 == true) 
{
 return;
}
else if (Player1.Bought8 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 150f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 14)
			{
				spriteRenderer.sprite = fourteen;
				if (Bought9 == true) 
{
 return;
}
else if (Player1.Bought9 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 140f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 15)
			{
				spriteRenderer.sprite = fifeteen;
				if (Bought10 == true) 
{
 return;
}
else if (Player1.Bought10 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 160f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 16)
			{
				spriteRenderer.sprite = sixteen;
				if (Bought11 == true) 
{
 return;
}
else if (Player1.Bought11 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 17)
			{
				spriteRenderer.sprite = seventeen;
				if (Bought12 == true) 
{
 return;
}
else if (Player1.Bought12 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 180f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 18)
			{
				spriteRenderer.sprite = eighteen;
				CommunityChanceCard2.SetActive(true);
			}
			if (theStateManager.numberOfTilesPlayer2 == 19)
			{
				spriteRenderer.sprite = nineteen;
				if (Bought13 == true) 
{
 return;
}
else if (Player1.Bought13 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 180f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 20)
			{
				spriteRenderer.sprite = twenty;
				if (Bought14 == true) 
{
 return;
}
else if (Player1.Bought14 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 21)
			{
				spriteRenderer.sprite = twentyone;
			}
			if (theStateManager.numberOfTilesPlayer2 == 22)
			{
				spriteRenderer.sprite = twentytwo;
				if (Bought15 == true) 
{
 return;
}
else if (Player1.Bought15 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 220f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 23)
			{
				spriteRenderer.sprite = twentythree;
				ChanceCard2.SetActive(true);
			}
			if (theStateManager.numberOfTilesPlayer2 == 24)
			{
				spriteRenderer.sprite = twentyfour;
				if (Bought16 == true) 
{
 return;
}
else if (Player1.Bought16 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 220f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 25)
			{
				spriteRenderer.sprite = twentyfive;
				if (Bought17 == true) 
{
 return;
}
else if (Player1.Bought17 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 240f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 26)
			{
				spriteRenderer.sprite = twentysix;
				if (Bought18 == true) 
{
 return;
}
else if (Player1.Bought18 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 27)
			{
				spriteRenderer.sprite = twentyseven;
				if (Bought19 == true) 
{
 return;
}
else if (Player1.Bought19 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 260f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 28)
			{
				spriteRenderer.sprite = twentyeight;
				if (Bought20 == true) 
{
 return;
}
else if (Player1.Bought20 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 260f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 29)
			{
				spriteRenderer.sprite = twentynine;
				if (Bought21 == true) 
{
 return;
}
else if (Player1.Bought21 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 150f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 30)
			{
				spriteRenderer.sprite = thirty;
				if (Bought22 == true) 
{
 return;
}
else if (Player1.Bought22 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 280;
			}
			if (theStateManager.numberOfTilesPlayer2 == 31)
			{
				spriteRenderer.sprite = thirtyone;
			}
			if (theStateManager.numberOfTilesPlayer2 == 32)
			{
				spriteRenderer.sprite = thirtytwo;
				if (Bought23 == true) 
{
 return;
}
else if (Player1.Bought23 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 300f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 33)
			{
				spriteRenderer.sprite = thirtythree;
				if (Bought24 == true) 
{
 return;
}
else if (Player1.Bought24 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 300f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 34)
			{
				spriteRenderer.sprite = thirtyfour;
				CommunityChanceCard2.SetActive(true);
			}
			if (theStateManager.numberOfTilesPlayer2 == 35)
			{
				spriteRenderer.sprite = thirtyfive;
				if (Bought25 == true) 
{
 return;
}
else if (Player1.Bought25 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 320f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 36)
			{
				spriteRenderer.sprite = thirtysix;
				if (Bought26 == true) 
{
 return;
}
else if (Player1.Bought26 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 37)
			{
				spriteRenderer.sprite = thirtyseven;
				ChanceCard2.SetActive(true);
			}
			if (theStateManager.numberOfTilesPlayer2 == 38)
			{
				spriteRenderer.sprite = thirtyeight;
				if (Bought27 == true) 
{
 return;
}
else if (Player1.Bought27 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 350f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 39)
			{
				spriteRenderer.sprite = thirtynine;
				Player2Money -= 200f;
			}
			if (theStateManager.numberOfTilesPlayer2 == 40)
			{
				spriteRenderer.sprite = fourty;
				if (Bought28 == true) 
{
 return;
}
else if (Player1.Bought28 == true) 
{
 RentCard2.SetActive(true);
 RentCard2.GetComponent<RentCard2>().RentPrice = 60f;
}
else
{
 BuyCard2.SetActive(true);
}

				BuyCard2.GetComponent<BuyCard2>().BuyPrice = 400f;
			}



		}

	}

	void SetNewTargetPosition(Vector3 pos)
	{
		targetPosition = pos;
		velocity = Vector3.zero;
	}

	void OnMouseUp()
	{
		// TODO:  Is the mouse over a UI element? In which case, ignore this click.

		if (theStateManager.CurrentPlayerId == 0)
		{
			return;
		}

		// Have we rolled the dice?
		if (theStateManager.IsDoneRolling == false)
		{
			// We can't move yet.
			return;
		}
		if (theStateManager.IsDoneClicking == true)
		{
			// We've already done a move!
			return;
		}

		int spacesToMove = theStateManager.DiceTotal;


		if (spacesToMove == 0)
		{
			return;
		}

		// Where should we end up?

		moveQueue = new Tile[spacesToMove];
		Tile finalTile = currentTile;

		for (int i = 0; i < spacesToMove; i++)
		{
			if (finalTile == null && scoreMe == false)
			{
				finalTile = StartingTile;
			}
			else
			{
				if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
				{
					// TODO: We have reached the end and must score.
					//Debug.Log("SCORE!");
					//Destroy(gameObject);
					//return;
					scoreMe = true;
					finalTile = null;
				}
				else if (finalTile.NextTiles.Length > 1)
				{
					// TODO: Branch based on player id
					finalTile = finalTile.NextTiles[0];
				}
				else
				{
					finalTile = finalTile.NextTiles[0];
				}
			}

			moveQueue[i] = finalTile;
		}

		// TODO: Check to see if the destination is legal!

		moveQueueIndex = 0;
		currentTile = finalTile;
		theStateManager.IsDoneClicking = true;
		this.isAnimating = true;
	}

}
