using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailChoicesPlayer1 : MonoBehaviour {

	public PlayerStone Player;
	public GameObject This;
	public GameObject DiceRoller;
	public StateManager sm;

	// Use this for initialization
	void Start() {
	}

	// Update is called once per frame
	void Update() {

	}


	public void Pay50()
	{
		Player.Player1Money -= 50f;
		This.SetActive(false);
		Player.inJail = false;
	}

	public void UseCard()
	{

	}

	public void RollDoubles()
	{

		This.SetActive(false);
		if (DiceRoller.GetComponent<DiceRoller>().DiceValues[0] == DiceRoller.GetComponent<DiceRoller>().DiceValues[1])
		{
			Player.inJail = false;
		}
		else
		{
			sm.IsDoneRolling = true;
			sm.IsDoneClicking = true;
			sm.IsDoneAnimating = true;
		}
	}
}
