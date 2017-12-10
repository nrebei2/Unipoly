using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCard : MonoBehaviour {

	public GameObject BuyThing;
	private PlayerStone Player;
	private StateManager sm;
	
	// ALL CARD SPRITES
	public GameObject[] CardImage;

	public float BuyPrice = 200f;
	
	public void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStone>();
		sm = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
	} 

	public void Buy()
	{
		BuyThing.SetActive(false);
		Player.Player1Money -= BuyPrice;

		if (sm.numberOfTiles == 2)
		{
			CardImage[0].SetActive(true);
			Player.Bought1 = true;
		}
		if (sm.numberOfTiles == 4)
		{
			CardImage[1].SetActive(true);
			Player.Bought2 = true;
		}
		if (sm.numberOfTiles == 6)
		{
			CardImage[2].SetActive(true);
			Player.Bought3 = true;
		}
		if (sm.numberOfTiles == 7)
		{
			CardImage[3].SetActive(true);
			Player.Bought4 = true;
		}
		if (sm.numberOfTiles == 9)
		{
			CardImage[4].SetActive(true);
			Player.Bought5 = true;
		}
		if (sm.numberOfTiles == 10)
		{
			CardImage[5].SetActive(true);
			Player.Bought6 = true;
		}
		if (sm.numberOfTiles == 12)
		{
			CardImage[6].SetActive(true);
			Player.Bought7 = true;
		}
		if (sm.numberOfTiles == 13)
		{
			CardImage[7].SetActive(true);
			Player.Bought8 = true;
		}
		if (sm.numberOfTiles == 14)
		{
			CardImage[8].SetActive(true);
			Player.Bought9 = true;
		}
		if (sm.numberOfTiles == 15)
		{
			CardImage[9].SetActive(true);
			Player.Bought10 = true;
		}
		if (sm.numberOfTiles == 16)
		{
			CardImage[10].SetActive(true);
			Player.Bought11 = true;
		}
		if (sm.numberOfTiles == 17)
		{
			CardImage[11].SetActive(true);
			Player.Bought12 = true;
		}
		if (sm.numberOfTiles == 19)
		{
			CardImage[12].SetActive(true);
			Player.Bought13 = true;
		}
		if (sm.numberOfTiles == 20)
		{
			CardImage[13].SetActive(true);
			Player.Bought14 = true;
		}
		if (sm.numberOfTiles == 22)
		{
			CardImage[14].SetActive(true);
			Player.Bought15 = true;
		}
		if (sm.numberOfTiles == 24)
		{
			CardImage[15].SetActive(true);
			Player.Bought16 = true;
		}
		if (sm.numberOfTiles == 25)
		{
			CardImage[16].SetActive(true);
			Player.Bought17 = true;
		}
		if (sm.numberOfTiles == 26)
		{
			CardImage[17].SetActive(true);
			Player.Bought18 = true;
		}
		if (sm.numberOfTiles == 27)
		{
			CardImage[18].SetActive(true);
			Player.Bought19 = true;
		}
		if (sm.numberOfTiles == 28)
		{
			CardImage[19].SetActive(true);
			Player.Bought20 = true;
		}
		if (sm.numberOfTiles == 29)
		{
			CardImage[20].SetActive(true);
			Player.Bought21 = true;
		}
		if (sm.numberOfTiles == 30)
		{
			CardImage[21].SetActive(true);
			Player.Bought22 = true;
		}
		if (sm.numberOfTiles == 32)
		{
			CardImage[22].SetActive(true);
			Player.Bought23 = true;
		}
		if (sm.numberOfTiles == 33)
		{
			CardImage[23].SetActive(true);
			Player.Bought24 = true;
		}
		if (sm.numberOfTiles == 35)
		{
			CardImage[24].SetActive(true);
			Player.Bought25 = true;
		}
		if (sm.numberOfTiles == 36)
		{
			CardImage[25].SetActive(true);
			Player.Bought26 = true;
		}
		if (sm.numberOfTiles == 38)
		{
			CardImage[26].SetActive(true);
			Player.Bought27 = true;
		}
		if (sm.numberOfTiles == 40)
		{
			CardImage[27].SetActive(true);
			Player.Bought28 = true;
		}

	}
	public void Close()
	{
		BuyThing.SetActive(false);
	}
}
