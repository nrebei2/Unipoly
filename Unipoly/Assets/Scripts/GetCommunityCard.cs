using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCommunityCard : MonoBehaviour
{

	public GameObject CommunityChanceCard;
	private PlayerStone Player;

	public float CollectPrice = 200f;

	public void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStone>();
	}

	public void Get()
	{
		CommunityChanceCard.SetActive(false);
		Player.Player1Money += CollectPrice;
	}
	public void Close()
	{
		CommunityChanceCard.SetActive(false);
	}
}
