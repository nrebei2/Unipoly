using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCommunityCard2 : MonoBehaviour
{

	public GameObject CommunityChanceCard;
	private Player2Stone Player;

	public float CollectPrice = 200f;

	public void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Stone>();
	}

	public void Get()
	{
		CommunityChanceCard.SetActive(false);
		Player.Player2Money += CollectPrice;
	}
	public void Close()
	{
		CommunityChanceCard.SetActive(false);
	}
}
