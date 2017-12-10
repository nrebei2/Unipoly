using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		
    }

	public PlayerStone Player1;
	public GameObject JailChoices1;

	public Player2Stone Player2;
	public GameObject JailChoices2;

	public int NumberOfPlayers = 2;
    public int CurrentPlayerId = 0;

	public string CurrentPlayerText;

    public int DiceTotal;

	public int numberOfTiles = 0;
	public int numberOfTilesPlayer2 = 0;

	public GameObject DiceRoller;

	public bool IsDoneRolling = false;
    public bool IsDoneClicking = false;
    public bool IsDoneAnimating = false;

	public GameObject SettingsMenu;

    public void NewTurn()
    {
        // This is the start of a player's turn.
        // We don't have a roll for them yet.
        IsDoneRolling = false;
        IsDoneClicking = false;
        IsDoneAnimating = false;

		if (DiceRoller.GetComponent<DiceRoller>().DiceValues[0] == DiceRoller.GetComponent<DiceRoller>().DiceValues[1])
		{
			CurrentPlayerId = CurrentPlayerId;
		}
		else
		{
			CurrentPlayerId = (CurrentPlayerId + 1) % NumberOfPlayers;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (Player1.inJail == true && CurrentPlayerId == 0 && IsDoneRolling == false)
		{
			JailChoices1.SetActive(true);
		}

		if (Player2.inJail == true && CurrentPlayerId == 1 && IsDoneRolling == false)
		{
			JailChoices2.SetActive(true);
		}


		// Is the turn done?
		if (IsDoneRolling && IsDoneClicking && IsDoneAnimating)
        {
            Debug.Log("Turn is done!");
            NewTurn();
        }

		if (CurrentPlayerId == 0)
		{
			CurrentPlayerText = "Current Player: One";
		}
		else if (CurrentPlayerId == 1)
		{
			CurrentPlayerText = "Current Player: Two";
		}

    }

	public void OnSettingsClick()
	{
		SettingsMenu.SetActive(true);
	}

	public void OnSettingsAccept()
	{
		SettingsMenu.SetActive(false);
	}
}
