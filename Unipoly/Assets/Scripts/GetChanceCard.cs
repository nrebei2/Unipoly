using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChanceCard : MonoBehaviour
{

	public GameObject ChanceCard;
	private PlayerStone Player;

	public float CollectPrice = 50f;

	public void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStone>();
	}

	public void Get()
	{
		ChanceCard.SetActive(false);
		Player.Player1Money += CollectPrice;
	}
	public void Close()
	{
		ChanceCard.SetActive(false);
	}
}
