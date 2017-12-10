using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Money : MonoBehaviour
{
	private Player2Stone Player2;

	// Use this for initialization
	void Start()
	{
		Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Stone>();
	}

	// Update is called once per frame
	void Update()
	{
		GetComponent<Text>().text = "Player 2: $" + Player2.Player2Money;
	}
}
