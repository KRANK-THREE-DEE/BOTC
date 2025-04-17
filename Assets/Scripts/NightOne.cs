using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class NightOne : MonoBehaviour
{
    public TMP_Text gameText;
	public string currentRole;
	public GameObject RoleManager;
	public List<string> roleList;
	public List<string> townsfolkInPlay;

	public GameObject Scroll;
	public TMP_Text infoText;

	public GameObject offscreenLocation;
	public GameObject onscreenLocation;

	void Start()
	{
		Scroll.transform.position = offscreenLocation.transform.position;
		infoText.gameObject.transform.position = offscreenLocation.transform.position;

		roleList = RoleManager.GetComponent<AssignCharacters>().GetAssignedRoleNames(); //list of all roles that have been assigned to players in game

		float duration = 5f;
		StartCoroutine(StartNight(duration));
	}

	public void ChangeRole() //runs every time the done button is hit to change to next role
	{
		print("RUNNING");
		if (currentRole == "poisoner")
		{
			Debug.Log("THE CURRENT ROLE IS " + currentRole);  
			Scroll.transform.position = offscreenLocation.transform.position;
			Spy();
		}
		else
		if (currentRole == "spy")
		{
			Debug.Log("THE CURRENT ROLE IS " + currentRole);  
			Washerwoman(); 
		}
		else 
		if(currentRole == "washerwoman")
		{
			infoText.text = "";
			Librarian();
		}
		else
			if (currentRole == "librarian")
		{
			infoText.text = "";
			Investigator();
		}
		else
		if (currentRole == "investigator")
		{
			infoText.text = "";
			Chef();
		}
	}


	IEnumerator StartNight(float duration)
	{
		gameText.text = "Take a sec, go to sleep.";
		Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
		yield return new WaitForSeconds(duration);
		Debug.Log($"Ended at {Time.time}");
		//whatever thing has minions wake up here. probably audio cue.
		if (GameManager.Instance.playerNumber >= 7)
		{
			StartCoroutine(Minions(5f));
		}
		else
		{
			Poisoner();
		}
	}


	IEnumerator Minions(float delay) //time for minions to see each other (only if 7 or more players)
	{
		gameText.text = "minions do ur thing (big game)";
		Debug.Log($"Started at {Time.time}");
		yield return new WaitForSeconds(5);
		Debug.Log($"Ended at {Time.time}");
		//whatever thing has minions sleep here.
		StartCoroutine(Demon(15f));
	}

	IEnumerator Demon(float delay) //time for demon to see who minions are and get bluffs (only if 7 or more players)
	{
		gameText.text = "demon do ur thing (big game)";
		//whatever thing has minions stick thumb out (or jackbox jus showing names on phone)
		Debug.Log($"Started at {Time.time}");
		yield return new WaitForSeconds(5);
		Debug.Log($"Ended at {Time.time}");
		gameText.text = "Timer done.";
		//minions put thumbs down
		//demon sees 3 not in play roles to bluff as
		//whatever thing has demons sleep here.
		Poisoner();
	}

	public void Poisoner()
	{
		Scroll.transform.position = onscreenLocation.transform.position;
		currentRole = "poisoner";
		gameText.text = "poisoner do ur thing";
		//display players on screen (scroll view same as roles earlier)
		//poisoner chooses one to poison
		//make that person poisoned
		//if poisoner role not in game waits random time between 8-15 seconds
		//poisoner sleeps
	}

	public void Spy()
	{
		currentRole = "spy";
		gameText.text = "spy do ur thing";
		//can't program spy yet, he's hella complicated
	}

	public void Washerwoman()
	{
		infoText.gameObject.transform.position = onscreenLocation.transform.position;
		currentRole = "washerwoman";
		gameText.text = "washerwoman do ur thing";
		List<Player> allPlayers = RoleManager.GetComponent<AssignCharacters>().GetPlayers();
		List<Player> allTown = new List<Player>();
		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Townsfolk)
			{
				allTown.Add(x);
			}
		}
		int random = Random.Range(0, allTown.Count);
		Player selectedTown = allTown[random];
		int random2 = Random.Range(0,allPlayers.Count);
		Player selectedRandom = allPlayers[random2];
		while(selectedTown == selectedRandom || selectedRandom.characterName == "Washerwoman" || selectedTown.characterName == "Washerwoman")
		{
			random = Random.Range(0, allTown.Count);
			selectedTown = allTown[random];
			random2 = Random.Range(0, allPlayers.Count);
			selectedRandom = allPlayers[random2];
		}
		print("Selected Town: " + selectedTown.playerName + " is the " + selectedTown.characterName);
		print("Selected Random: " + selectedRandom.playerName + " is the " + selectedRandom.characterName);
		infoText.text += "Either " + selectedTown.playerName + " or " + selectedRandom.playerName + " is the " + selectedTown.characterName + ".";
	}

	public void Librarian()
	{
		currentRole = "librarian";
		gameText.text = "librarian do ur thing";
		List<Player> allPlayers = RoleManager.GetComponent<AssignCharacters>().GetPlayers();
		List<Player> allOutsiders = new List<Player>();
		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Outsider)
			{
				allOutsiders.Add(x);
			}
		}
		if (allOutsiders.Count == 0)
		{
			infoText.text += "There are no Outsiders!";
		}
		else
		{
			int random = Random.Range(0, allOutsiders.Count);
			Player selectedOutsider = allOutsiders[random];
			int random2 = Random.Range(0, allPlayers.Count);
			Player selectedRandom = allPlayers[random2];
			while (selectedOutsider == selectedRandom || selectedRandom.characterName == "Librarian" || selectedOutsider.characterName == "Librarian")
			{
				random = Random.Range(0, allOutsiders.Count);
				selectedOutsider = allOutsiders[random];
				random2 = Random.Range(0, allPlayers.Count);
				selectedRandom = allPlayers[random2];
			}
			print("Selected Outsider: " + selectedOutsider.playerName + " is the " + selectedOutsider.characterName);
			print("Selected Random: " + selectedRandom.playerName + " is the " + selectedRandom.characterName);
			infoText.text += "Either " + selectedOutsider.playerName + " or " + selectedRandom.playerName + " is the " + selectedOutsider.characterName + ".";
		}

	}

	public void Investigator()
	{
		currentRole = "investigator";
		gameText.text = "investigator do ur thing";
		List<Player> allPlayers = RoleManager.GetComponent<AssignCharacters>().GetPlayers();
		List<Player> allMinions = new List<Player>();
		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Minion)
			{
				allMinions.Add(x);
			}
		}
		int random = Random.Range(0, allMinions.Count);
		Player selectedMinion = allMinions[random];
		int random2 = Random.Range(0, allPlayers.Count);
		Player selectedRandom = allPlayers[random2];
		while (selectedMinion == selectedRandom || selectedRandom.characterName == "Washerwoman" || selectedMinion.characterName == "Washerwoman")
		{
			random = Random.Range(0, allMinions.Count);
			selectedMinion = allMinions[random];
			random2 = Random.Range(0, allPlayers.Count);
			selectedRandom = allPlayers[random2];
		}
		print("Selected Town: " + selectedMinion.playerName + " is the " + selectedMinion.characterName);
		print("Selected Random: " + selectedRandom.playerName + " is the " + selectedRandom.characterName);
		infoText.text += "Either " + selectedMinion.playerName + " or " + selectedRandom.playerName + " is the " + selectedMinion.characterName + ".";
	}

	public void Chef()
	{
		currentRole = "chef";
		gameText.text = "investigator do ur thing";
		//Shows 0, 1, 2, etc for # of evil players sitting next to each other (counts first and last position as sitting next to each other
		List<Player> allPlayers = RoleManager.GetComponent<AssignCharacters>().GetPlayers();
		int chefCounter = 0;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			Player current = allPlayers[i]; //i is the current index starting at 0
			Player next = allPlayers[(i + 1) % allPlayers.Count]; // wrap around using %
			bool currentIsEvil = current.alignment == CharacterLibrary.Alignment.Minion || current.alignment == CharacterLibrary.Alignment.Demon;
			bool nextIsEvil = next.alignment == CharacterLibrary.Alignment.Minion || next.alignment == CharacterLibrary.Alignment.Demon;

			if (currentIsEvil && nextIsEvil)
			{
				chefCounter++;
			}
		}
		if (chefCounter == 1)
		{
			infoText.text += "There is " + chefCounter.ToString() + " pair of evil players sitting next to each other.";
		}
		else
		{
			infoText.text += "There are " + chefCounter.ToString() + " pairs of evil players sitting next to each other.";
		}

	}
}
