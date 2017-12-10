using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStone : MonoBehaviour
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
			spriteRenderer.sprite = one; // set the sprite to sprite1

		CommunitySpriteRenderer = ImageOfCommunityChanceCard.GetComponent<Image>(); // we are accessing the Image that is attached to the Gameobject
		if (CommunitySpriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			CommunitySpriteRenderer.sprite = CommunityChance[0]; // set the sprite to sprite1

		ChanceSpriteRenderer = ImageOfChanceCard.GetComponent<Image>(); // we are accessing the Image that is attached to the Gameobject
		if (ChanceSpriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			ChanceSpriteRenderer.sprite = Chance[0]; // set the sprite to sprite1
	}

    public Tile StartingTile;
    Tile currentTile;

    bool scoreMe = false;

	public float Player1Money = 1500f;

    StateManager theStateManager;

    Tile[] moveQueue;
    int moveQueueIndex;

    bool isAnimating = false;
	public bool inJail = false;

	public GameObject BuyCard;
	public GameObject RentCard;
	public GameObject CommunityChanceCard;
	public GameObject ChanceCard;

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

	public Player2Stone Player2;

	public GameObject Player2Win;

	// Update is called once per frame
	void Update()
    {

		if (Player1Money <= 0f)
		{
			Player1Money = 0f;
			Player2Win.SetActive(true);
		}


		if (theStateManager.CurrentPlayerId == 0)
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

		if (theStateManager.numberOfTiles == 41)
		{
			theStateManager.numberOfTiles = 1;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 42)
		{
			theStateManager.numberOfTiles = 2;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 43)
		{
			theStateManager.numberOfTiles = 3;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 44)
		{
			theStateManager.numberOfTiles = 4;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 45)
		{
			theStateManager.numberOfTiles = 5;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 46)
		{
			theStateManager.numberOfTiles = 6;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 47)
		{
			theStateManager.numberOfTiles = 7;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 48)
		{
			theStateManager.numberOfTiles = 8;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 49)
		{
			theStateManager.numberOfTiles = 9;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 50)
		{
			theStateManager.numberOfTiles = 10;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 51)
		{
			theStateManager.numberOfTiles = 11;
			Player1Money += 200f;
		}
		if (theStateManager.numberOfTiles == 52)
		{
			theStateManager.numberOfTiles = 12;
			Player1Money += 200f;
		}

	}

    void AdvanceMoveQueue()
    {
		if (theStateManager.CurrentPlayerId == 1 || inJail == true)
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
			theStateManager.numberOfTiles += theStateManager.DiceTotal;
			Debug.Log("Done animating!");
            this.isAnimating = false;
            theStateManager.IsDoneAnimating = true;
			// TODO: ADD UI



			if (theStateManager.numberOfTiles == 1)
			{
				spriteRenderer.sprite = one;
			}
			if (theStateManager.numberOfTiles == 2)
			{
				spriteRenderer.sprite = two;
				if (Bought1 == true) 
{
 return;
}
else if (Player2.Bought1 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 60f;
			}
			if (theStateManager.numberOfTiles == 3)
			{
				spriteRenderer.sprite = three;
				CommunityChanceCard.SetActive(true);
			}
			if (theStateManager.numberOfTiles == 4)
			{
				spriteRenderer.sprite = four;
				if (Bought2 == true) 
{
 return;
}
else if (Player2.Bought2 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 60f;
			}
			if (theStateManager.numberOfTiles == 5)
			{
				spriteRenderer.sprite = five;
				Player1Money -= 200f;
			}
			if (theStateManager.numberOfTiles == 6)
			{
				spriteRenderer.sprite = six;
				if (Bought3 == true) 
{
 return;
}
else if (Player2.Bought3 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTiles == 7)
			{
				spriteRenderer.sprite = seven;
				if (Bought4 == true) 
{
 return;
}
else if (Player2.Bought4 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 100f;
			}
			if (theStateManager.numberOfTiles == 8)
			{
				spriteRenderer.sprite = eight;
				ChanceCard.SetActive(true);
			}
			if (theStateManager.numberOfTiles == 9)
			{
				spriteRenderer.sprite = nine;
				if (Bought5 == true) 
{
 return;
}
else if (Player2.Bought5 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 100f;
			}
			if (theStateManager.numberOfTiles == 10)
			{
				spriteRenderer.sprite = ten;
				if (Bought6 == true) 
{
 return;
}
else if (Player2.Bought6 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 120f;
			}
			if (theStateManager.numberOfTiles == 11)
			{
				inJail = true;
				spriteRenderer.sprite = eleven;
			}
			if (theStateManager.numberOfTiles == 12)
			{
				spriteRenderer.sprite = twleve;
				if (Bought7 == true) 
{
 return;
}
else if (Player2.Bought7 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 140f;
			}
			if (theStateManager.numberOfTiles == 13)
			{
				spriteRenderer.sprite = thirteen;
				if (Bought8 == true) 
{
 return;
}
else if (Player2.Bought8 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 150f;
			}
			if (theStateManager.numberOfTiles == 14)
			{
				spriteRenderer.sprite = fourteen;
				if (Bought9 == true) 
{
 return;
}
else if (Player2.Bought9 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 140f;
			}
			if (theStateManager.numberOfTiles == 15)
			{
				spriteRenderer.sprite = fifeteen;
				if (Bought10 == true) 
{
 return;
}
else if (Player2.Bought10 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 160f;
			}
			if (theStateManager.numberOfTiles == 16)
			{
				spriteRenderer.sprite = sixteen;
				if (Bought11 == true) 
{
 return;
}
else if (Player2.Bought11 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTiles == 17)
			{
				spriteRenderer.sprite = seventeen;
				if (Bought12 == true) 
{
 return;
}
else if (Player2.Bought12 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 180f;
			}
			if (theStateManager.numberOfTiles == 18)
			{
				spriteRenderer.sprite = eighteen;
				CommunityChanceCard.SetActive(true);
			}
			if (theStateManager.numberOfTiles == 19)
			{
				spriteRenderer.sprite = nineteen;
				if (Bought13 == true) 
{
 return;
}
else if (Player2.Bought13 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 180f;
			}
			if (theStateManager.numberOfTiles == 20)
			{
				spriteRenderer.sprite = twenty;
				if (Bought14 == true) 
{
 return;
}
else if (Player2.Bought14 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTiles == 21)
			{
				spriteRenderer.sprite = twentyone;
			}
			if (theStateManager.numberOfTiles == 22)
			{
				spriteRenderer.sprite = twentytwo;
				if (Bought15 == true) 
{
 return;
}
else if (Player2.Bought15 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 220f;
			}
			if (theStateManager.numberOfTiles == 23)
			{
				spriteRenderer.sprite = twentythree;
				ChanceCard.SetActive(true);
			}
			if (theStateManager.numberOfTiles == 24)
			{
				spriteRenderer.sprite = twentyfour;
				if (Bought16 == true) 
{
 return;
}
else if (Player2.Bought16 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 220f;
			}
			if (theStateManager.numberOfTiles == 25)
			{
				spriteRenderer.sprite = twentyfive;
				if (Bought17 == true) 
{
 return;
}
else if (Player2.Bought17 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 240f;
			}
			if (theStateManager.numberOfTiles == 26)
			{
				spriteRenderer.sprite = twentysix;
				if (Bought18 == true) 
{
 return;
}
else if (Player2.Bought18 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTiles == 27)
			{
				spriteRenderer.sprite = twentyseven;
				if (Bought19 == true) 
{
 return;
}
else if (Player2.Bought19 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 260f;
			}
			if (theStateManager.numberOfTiles == 28)
			{
				spriteRenderer.sprite = twentyeight;
				if (Bought20 == true) 
{
 return;
}
else if (Player2.Bought20 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 260f;
			}
			if (theStateManager.numberOfTiles == 29)
			{
				spriteRenderer.sprite = twentynine;
				if (Bought21 == true) 
{
 return;
}
else if (Player2.Bought21 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 150f;
			}
			if (theStateManager.numberOfTiles == 30)
			{
				spriteRenderer.sprite = thirty;
				if (Bought22 == true) 
{
 return;
}
else if (Player2.Bought22 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 280;
			}
			if (theStateManager.numberOfTiles == 31)
			{
				spriteRenderer.sprite = thirtyone;
			}
			if (theStateManager.numberOfTiles == 32)
			{
				spriteRenderer.sprite = thirtytwo;
				if (Bought23 == true) 
{
 return;
}
else if (Player2.Bought23 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 300f;
			}
			if (theStateManager.numberOfTiles == 33)
			{
				spriteRenderer.sprite = thirtythree;
				if (Bought24 == true) 
{
 return;
}
else if (Player2.Bought24 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 300f;
			}
			if (theStateManager.numberOfTiles == 34)
			{
				spriteRenderer.sprite = thirtyfour;
				CommunityChanceCard.SetActive(true);
			}
			if (theStateManager.numberOfTiles == 35)
			{
				spriteRenderer.sprite = thirtyfive;
				if (Bought25 == true) 
{
 return;
}
else if (Player2.Bought25 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 320f;
			}
			if (theStateManager.numberOfTiles == 36)
			{
				spriteRenderer.sprite = thirtysix;
				if (Bought26 == true) 
{
 return;
}
else if (Player2.Bought26 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 200f;
			}
			if (theStateManager.numberOfTiles == 37)
			{
				spriteRenderer.sprite = thirtyseven;
				ChanceCard.SetActive(true);
			}
			if (theStateManager.numberOfTiles == 38)
			{
				spriteRenderer.sprite = thirtyeight;
				if (Bought27 == true) 
{
 return;
}
else if (Player2.Bought27 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 350f;
			}
			if (theStateManager.numberOfTiles == 39)
			{
				spriteRenderer.sprite = thirtynine;
				Player1Money -= 200f;
			}
			if (theStateManager.numberOfTiles == 40)
			{
				spriteRenderer.sprite = fourty;
				if (Bought28 == true) 
{
 return;
}
else if (Player2.Bought28 == true) 
{
 RentCard.SetActive(true);
 RentCard.GetComponent<RentCard>().RentPrice = 60f;
}
else
{
 BuyCard.SetActive(true);
}

				BuyCard.GetComponent<BuyCard>().BuyPrice = 400f;
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

		if (theStateManager.CurrentPlayerId == 1)
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
