using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RentOfCard2 : MonoBehaviour
{

	public GameObject RentCard;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		GetComponent<Text>().text = "$" + RentCard.GetComponent<RentCard2>().RentPrice;
	}
}
