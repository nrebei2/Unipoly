using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Money : MonoBehaviour
{
	private PlayerStone Player1;

	// Use this for initialization
	void Start()
	{
		Player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStone>();
	}

	// Update is called once per frame
	void Update()
	{
		GetComponent<Text>().text = "Player 1: $" + Player1.Player1Money;
	}
}
