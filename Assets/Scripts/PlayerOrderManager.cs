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
		if (GameManager.playerOrder.Count >= GameManager.playerNumber)
		{
			Debug.Log("Maximum number of players reached!");
			return;
		}

		if (!string.IsNullOrWhiteSpace(input.text))
		{
			GameManager.playerOrder.Add(new Player(input.text));
			GameManager.playerTotalNames.Add(input.text);
			print("Created Player: " +  input.text);
			input.text = ""; // Clear the input field after entering a name
			UpdatePlayerList(); // Update the on-screen list
		}

		Debug.Log("Player order saved!");
	}

	public void UpdatePlayerList()
	{
		playerList.text = "Players:\n";
		foreach (var player in GameManager.playerOrder)
		{
			playerList.text += $"{player.playerName}\n";
		}

	}

	public void UndoButton()
	{
		if (GameManager.playerOrder.Count >= 1)
		GameManager.playerOrder.RemoveAt(GameManager.playerOrder.Count - 1);
		UpdatePlayerList();
	}


	//methods that GPT added that i'll maybe probably need??
	public static Player GetNextPlayer(string currentPlayer)
	{
		int index = GameManager.playerOrder.FindIndex(p => p.playerName == currentPlayer);
		if (index == -1 || GameManager.playerOrder.Count == 0) return null;

		return GameManager.playerOrder[(index + 1) % GameManager.playerOrder.Count];
	}

	public static Player GetPreviousPlayer(string currentPlayer)
	{
		int index = GameManager.playerOrder.FindIndex(p => p.playerName == currentPlayer);
		if (index == -1 || GameManager.playerOrder.Count == 0) return null;

		return GameManager.playerOrder[(index - 1 + GameManager.playerOrder.Count) % GameManager.playerOrder.Count]; // Wrap around backward
	}
}