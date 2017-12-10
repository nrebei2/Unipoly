using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostOfCard2 : MonoBehaviour
{

	public GameObject BuyCard;

	// Update is called once per frame
	void Update()
	{
		// Gets the Text Component of the Object and equals it to the Buy price of the current open card
		GetComponent<Text>().text = "$" + BuyCard.GetComponent<BuyCard2>().BuyPrice;
	}
}
