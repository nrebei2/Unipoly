using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChanceCard2 : MonoBehaviour
{

	public GameObject ChanceCard;
	private Player2Stone Player;

	public float CollectPrice = 50f;

	public void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Stone>();
	}

	public void Get()
	{
		ChanceCard.SetActive(false);
		Player.Player2Money += CollectPrice;
	}
	public void Close()
	{
		ChanceCard.SetActive(false);
	}
}
