using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class PlayerOrderManager : MonoBehaviour
{
	public TMP_InputField input; 
	public Button enterButton;
	public TMP_Text playerList;


	public void SaveName()
	{
		if (GameManager.Instance.playerOrder.Count >= GameManager.Instance.playerNumber)
		{
			Debug.Log("Maximum number of players reached!");
			return;
		}

		if (!string.IsNullOrWhiteSpace(input.text))
		{
			GameManager.Instance.playerOrder.Add(new Player(input.text));
			GameManager.Instance.playerTotalNames.Add(input.text);
			print("Created Player: " +  input.text);
			input.text = ""; // Clear the input field after entering a name
			UpdatePlayerList(); // Update the on-screen list
		}

		Debug.Log("Player order saved!");
	}

	public void UpdatePlayerList()
	{
		playerList.text = "Players:\n";
		foreach (var player in GameManager.Instance.playerOrder)
		{
			playerList.text += $"{player.playerName}\n";
		}

	}

	public void UndoButton()
	{
		if (GameManager.Instance.playerOrder.Count >= 1)
		GameManager.Instance.playerOrder.RemoveAt(GameManager.Instance.playerOrder.Count - 1);
		UpdatePlayerList();
	}


	//methods that GPT added that i'll maybe probably need??
	public static Player GetNextPlayer(string currentPlayer) //the Player after static tells code to give me a Player
	{
		int x = GameManager.Instance.playerOrder.FindIndex(p => p.playerName == currentPlayer); //set x equal to ????
		return GameManager.Instance.playerOrder[(x + 1) % GameManager.Instance.playerOrder.Count];
	}

	public static Player GetPreviousPlayer(string currentPlayer)
	{
		int x2 = GameManager.Instance.playerOrder.FindIndex(p => p.playerName == currentPlayer);
		return GameManager.Instance.playerOrder[(x2 - 1 + GameManager.Instance.playerOrder.Count) % GameManager.Instance.playerOrder.Count]; // Wrap around backward
	}
}