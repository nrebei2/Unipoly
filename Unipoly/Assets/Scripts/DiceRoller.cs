using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DiceValues = new int[2];
        theStateManager = GameObject.FindObjectOfType<StateManager>();
    }

    StateManager theStateManager;

    public int[] DiceValues;

	public Sprite[] DiceImageSix;
	public Sprite[] DiceImageFive;
	public Sprite[] DiceImageFour;
	public Sprite[] DiceImageThree;
	public Sprite[] DiceImageTwo;
	public Sprite[] DiceImageOne;


    // Update is called once per frame
    void Update()
    {
		
    }

    public void RollTheDice()
    {

        if (theStateManager.IsDoneRolling == true)
        {
            // We've already rolled this turn.
            return;
        }

        // You COULD roll actual physics enabled dice.

        // We are going to use random number generation instead.

        theStateManager.DiceTotal = 0;
        for (int i = 0; i < DiceValues.Length; i++)
        {
            DiceValues[i] = Random.Range(1, 7);
            theStateManager.DiceTotal += DiceValues[i];

            // Update the visuals to show the dice roll
            // TODO: This could include playing an animation -- either 2D or 3D

            // We have 2 children, each is an image of the die. So grab that
            // child, and update its Image component to use the correct Sprite

            if (DiceValues[i] == 1)
			{
                this.transform.GetChild(i).GetComponent<Image>().sprite = 
                    DiceImageOne[Random.Range(0, DiceImageOne.Length)];                
            }
			else if (DiceValues[i] == 2)
			{
				this.transform.GetChild(i).GetComponent<Image>().sprite =
					DiceImageTwo[Random.Range(0, DiceImageTwo.Length)];
			}
			else if (DiceValues[i] == 3)
			{
				this.transform.GetChild(i).GetComponent<Image>().sprite =
					DiceImageThree[Random.Range(0, DiceImageThree.Length)];
			}
			else if (DiceValues[i] == 4)
			{
				this.transform.GetChild(i).GetComponent<Image>().sprite =
					DiceImageFour[Random.Range(0, DiceImageFour.Length)];
			}
			else if (DiceValues[i] == 5)
			{
				this.transform.GetChild(i).GetComponent<Image>().sprite =
					DiceImageFive[Random.Range(0, DiceImageFive.Length)];
			}
			else if (DiceValues[i] == 6)
			{
				this.transform.GetChild(i).GetComponent<Image>().sprite =
					DiceImageSix[Random.Range(0, DiceImageSix.Length)];
			}

			// If we had an animation, we'd have to wait for it to finish before
			// we set doneRolling, but we can just set it right away
			theStateManager.IsDoneRolling = true;

        }



        //Debug.Log("Rolled: " + DiceTotal);
    }
}
