using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static CharacterLibrary;

public class AssignCharacters : Singleton<AssignCharacters>
{
	public int minionNumber;
	public int townNumber;
	public int outsiderNumber;
	public int demonNumber = 1;

	// List of roles for each alignment
	private List<CharacterLibrary.CharacterRole> allTownsfolkRoles = new List<CharacterLibrary.CharacterRole>();
	private List<CharacterLibrary.CharacterRole> allOutsiderRoles = new List<CharacterLibrary.CharacterRole>();
	private List<CharacterLibrary.CharacterRole> allMinionRoles = new List<CharacterLibrary.CharacterRole>();
	private List<CharacterLibrary.CharacterRole> allDemonRoles = new List<CharacterLibrary.CharacterRole>();

	private List<Player> players = new List<Player>();


	void Start()
	{
		//allTownsfolkRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.townsfolkRoles);
		//allOutsiderRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.outsiderRoles);
		//allMinionRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.minionRoles);
		//allDemonRoles = new List<CharacterLibrary.CharacterRole>(CharacterLibrary.demonRoles);

		//print("STARTING FOR LOOP");
		for (int i = 0; i < GameManager.Instance.characterRolesInCurrentGame.Count; i++)
		{
			//print("LOOP: " + i);
			if (GameManager.Instance.characterRolesInCurrentGame[i].alignment == Alignment.Townsfolk)
			{
				allTownsfolkRoles.Add(GameManager.Instance.characterRolesInCurrentGame[i]);
			}
			else
			if (GameManager.Instance.characterRolesInCurrentGame[i].alignment == Alignment.Outsider)
			{
				allOutsiderRoles.Add(GameManager.Instance.characterRolesInCurrentGame[i]);
			}
			else
			if (GameManager.Instance.characterRolesInCurrentGame[i].alignment == Alignment.Demon)
			{
				allDemonRoles.Add(GameManager.Instance.characterRolesInCurrentGame[i]);
			}
			else
			if (GameManager.Instance.characterRolesInCurrentGame[i].alignment == Alignment.Minion)
			{
				allMinionRoles.Add(GameManager.Instance.characterRolesInCurrentGame[i]);
			}
		}

		players = new List<Player>(); // Initialize players list
		GameManager.Instance.UpdateAvailableRolesList();
		SetCharacterNumber();
		GivePlayerCharacters();
		GetAssignedRoleNames();
		Debug.Log("town: " + townNumber.ToString());
		Debug.Log("outsiders: " + outsiderNumber.ToString());
		Debug.Log("minions: " + minionNumber.ToString());
		Debug.Log("demons: " + demonNumber.ToString());
	}

	// Set the number of characters based on the player count

	public void SetCharacterNumber()
	{
		if (GameManager.Instance.playerNumber == 5)
		{
			townNumber = 3;
			outsiderNumber = 0;
			minionNumber = 1;
		}
		if (GameManager.Instance.playerNumber == 6)
		{
			townNumber = 3;
			outsiderNumber = 1;
			minionNumber = 1;
		}
		if (GameManager.Instance.playerNumber == 7)
		{
			townNumber = 5;
			outsiderNumber = 0;
			minionNumber = 1;
		}
		if (GameManager.Instance.playerNumber == 8)
		{
			townNumber = 5;
			outsiderNumber = 1;
			minionNumber = 1;
		}
		if (GameManager.Instance.playerNumber == 9)
		{
			townNumber = 5;
			outsiderNumber = 2;
			minionNumber = 1;
		}
		if (GameManager.Instance.playerNumber == 10)
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
		for (int i = 0; i < GameManager.Instance.playerNumber; i++)
		{
			players.Add(new Player(GameManager.Instance.playerTotalNames[i]));
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

		List<CharacterLibrary.CharacterRole> unassignedTownsfolkRoles = GetUnassignedRoles(allTownsfolkRoles, players);
		List<CharacterLibrary.CharacterRole> unassignedOutsiderRoles = GetUnassignedRoles(allOutsiderRoles, players);


		Debug.Log("Unassigned Townsfolk Roles:");
		foreach (var role in unassignedTownsfolkRoles)
		{
			Debug.Log(role.characterName);
		}

		Debug.Log("Unassigned Outsider Roles:");
		foreach (var role in unassignedOutsiderRoles)
		{
			Debug.Log(role.characterName);
		}

		GameManager.Instance.playerOrder = players;

		for (int i = 0; i < GameManager.Instance.playerNumber; i++)
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
				print("Attempting to Assign the: " + selectedRole.characterName);

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
		// Check if the player list is empty or contains less than 5 players
		if (players2 == null || players2.Count < 5) return;

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

	public List<string> GetAssignedRoleNames()
	{
		List<string> assignedRoleNames = new List<string>();

		foreach (var player in players)
		{
			if (player.characterName != "Unknown")
			{
				assignedRoleNames.Add(player.characterName);
			}
		}

		return assignedRoleNames;
	}

	public List<Player> GetPlayers()
	{
		return players;
	}

	private List<CharacterLibrary.CharacterRole> GetUnassignedRoles(List<CharacterLibrary.CharacterRole> allRoles, List<Player> players) //get full list of possible Demon bluffs
	{
		List<CharacterLibrary.CharacterRole> unassignedRoles = new List<CharacterLibrary.CharacterRole>();

		// Loop through the original list of all roles
		foreach (var role in allRoles)
		{
			bool isAssigned = false;

			// Check if this role is already assigned to any player
			foreach (var player in players)
			{
				if (player.characterName == role.characterName)
				{
					isAssigned = true;
					break;
				}
			}

			// If the role is not assigned, add it to the unassigned list
			if (!isAssigned)
			{
				unassignedRoles.Add(role);
			}
		}

		return unassignedRoles;
	}

	// Public method to get 3 random unassigned Townsfolk or Outsider roles for Demon bluffs
	public List<CharacterLibrary.CharacterRole> GetDemonBluffRoles()
	{
		// Get unassigned Townsfolk and Outsider roles
		List<CharacterLibrary.CharacterRole> unassignedTownsfolk = GetUnassignedRoles(allTownsfolkRoles, players);
		List<CharacterLibrary.CharacterRole> unassignedOutsiders = GetUnassignedRoles(allOutsiderRoles, players);

		// Combine both lists
		List<CharacterLibrary.CharacterRole> combinedList = new List<CharacterLibrary.CharacterRole>();
		combinedList.AddRange(unassignedTownsfolk);
		combinedList.AddRange(unassignedOutsiders);

		// Shuffle combined list
		System.Random rng = new System.Random();
		combinedList = combinedList.OrderBy(x => rng.Next()).ToList();

		// Take up to 3 roles (if less are available, it won�t throw an error)
		return combinedList.Take(3).ToList();
	}




}
