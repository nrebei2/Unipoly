using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentCard : MonoBehaviour {

	public GameObject RentThing;
	public float RentPrice = 50f;
	private PlayerStone Player;
	private Player2Stone Player2;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStone>();
		Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Stone>();
	}
	

	public void Pay()
	{
		RentThing.SetActive(false);
		Player.Player1Money -= RentPrice;
		Player2.Player2Money -= RentPrice;
	}
}
