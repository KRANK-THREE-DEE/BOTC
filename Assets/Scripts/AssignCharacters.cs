using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssignCharacters : MonoBehaviour
{
	public int minionNumber;
	public int townNumber;
	public int outsiderNumber;
	public int demonNumber = 1;

	// List of roles for each alignment
	private List<CharacterLibrary.CharacterRole> allTownsfolkRoles;
	private List<CharacterLibrary.CharacterRole> allOutsiderRoles;
	private List<CharacterLibrary.CharacterRole> allMinionRoles;
	private List<CharacterLibrary.CharacterRole> allDemonRoles;

	private List<Player> players;

	// Start is called before the first frame update
	void Start()
	{
		allTownsfolkRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.townsfolkRoles);
		allOutsiderRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.outsiderRoles);
		allMinionRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.minionRoles);
		allDemonRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.demonRoles);

		players = new List<Player>(); // Initialize players list

		SetCharacterNumber();
		GivePlayerCharacters();
		Debug.Log("town: " + townNumber.ToString());
		Debug.Log("outsiders: " + outsiderNumber.ToString());
		Debug.Log("minions: " + minionNumber.ToString());
		Debug.Log("demons: " + demonNumber.ToString());
	}

	// Set the number of characters based on the player count
	public void SetCharacterNumber()
	{
		if (GameManager.playerNumber == 5)
		{
			townNumber = 3;
			outsiderNumber = 0;
			minionNumber = 1;
		}
		if (GameManager.playerNumber == 6)
		{
			townNumber = 3;
			outsiderNumber = 1;
			minionNumber = 1;
		}
		if (GameManager.playerNumber == 7)
		{
			townNumber = 5;
			outsiderNumber = 0;
			minionNumber = 1;
		}
		if (GameManager.playerNumber == 8)
		{
			townNumber = 5;
			outsiderNumber = 1;
			minionNumber = 1;
		}
		if (GameManager.playerNumber == 9)
		{
			townNumber = 5;
			outsiderNumber = 2;
			minionNumber = 1;
		}
		if (GameManager.playerNumber == 10)
		{
			townNumber = 7;
			outsiderNumber = 0;
			minionNumber = 2;
		}
	}

	// Give characters to players
	public void GivePlayerCharacters()
	{
		// Create players and assign them roles
		for (int i = 0; i < GameManager.playerNumber; i++)
		{
			players.Add(new Player("Player " + (i + 1)));
		}

		// Assign Townsfolk roles
		AssignRoles(allTownsfolkRoles, townNumber);

		// Assign Outsider roles
		AssignRoles(allOutsiderRoles, outsiderNumber);

		// Assign Minion roles
		AssignRoles(allMinionRoles, minionNumber);

		// Assign Demon roles
		AssignRoles(allDemonRoles, demonNumber);

		ShuffleCharacterNamesAndAlignments(players);
		for(int i = 0; i < GameManager.playerNumber; i++)
		{
			Debug.Log(players[i].playerName + " is assigned " + players[i].characterName);
		}
	}

	// Helper method to assign roles
	private void AssignRoles(List<CharacterLibrary.CharacterRole> roleList, int numberOfRolesToAssign)
	{
		for (int i = 0; i < numberOfRolesToAssign; i++)
		{
			if (roleList.Count > 0)
			{
				int randomIndex = Random.Range(0, roleList.Count);
				CharacterLibrary.CharacterRole selectedRole = roleList[randomIndex];


				// Assign the role to a player
				if (players[i].characterName == "Unknown")
				{
					roleList.RemoveAt(randomIndex); // Remove the selected role
					players[i].characterName = selectedRole.characterName;
					players[i].alignment = selectedRole.alignment;

				}
				else
				{
					numberOfRolesToAssign++;
				}


			}
			else
			{
				Debug.LogError("Not enough roles to assign!");
			}
		}
	}





	public void ShuffleCharacterNamesAndAlignments(List<Player> players2)
	{
		// Check if the player list is empty or contains one player
		if (players2 == null || players2.Count < 2) return;

		// Create a random number generator
		System.Random random = new System.Random();

		// Shuffle the character names and alignments separately
		List<string> shuffledCharacterNames = new List<string>();
		List<CharacterLibrary.Alignment> shuffledAlignments = new List<CharacterLibrary.Alignment>();

		foreach (var player in players2)
		{
			shuffledCharacterNames.Add(player.characterName);
			shuffledAlignments.Add(player.alignment);
		}

		// Shuffle character names and alignment
		for (int i = shuffledCharacterNames.Count - 1; i > 0; i--)
		{
			int j = random.Next(i + 1);
			string temp = shuffledCharacterNames[i];
			shuffledCharacterNames[i] = shuffledCharacterNames[j];
			shuffledCharacterNames[j] = temp;

			CharacterLibrary.Alignment temp2 = shuffledAlignments[i];
			shuffledAlignments[i] = shuffledAlignments[j];
			shuffledAlignments[j] = temp2;
		}


		// Reassign the shuffled values back to the players
		for (int i = 0; i < players2.Count; i++)
		{
			players2[i].characterName = shuffledCharacterNames[i];
			players2[i].alignment = shuffledAlignments[i];
		}
		players = players2;
	}






}
