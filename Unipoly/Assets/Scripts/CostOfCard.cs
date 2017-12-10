using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostOfCard : MonoBehaviour {

	public GameObject BuyCard;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Text>().text = "$" + BuyCard.GetComponent<BuyCard>().BuyPrice;
	}
}
