using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UIElements;
using static CharacterLibrary;

public class NightOne : MonoBehaviour
{
    public TMP_Text gameText;
	public string currentRole;
	public List<string> roleList;
	public List<string> townsfolkInPlay;

	public GameObject Scroll;
	public TMP_Text infoText;

	public GameObject offscreenLocation;
	public GameObject onscreenLocation;

	public bool butlerDone;

	public GameObject DoneButton;

	public GameObject spyPlayerButton;
	public GameObject spyTownButton;
	public GameObject spyOutsiderButton;
	public GameObject spyEvilButton;

	public bool currentPoisoned;


	void Start()
	{
		spyPlayerButton.gameObject.SetActive(false);
		spyTownButton.gameObject.SetActive(false);
		spyOutsiderButton.gameObject.SetActive(false);
		spyEvilButton.gameObject.SetActive(false);
		Scroll.transform.position = offscreenLocation.transform.position;
		infoText.gameObject.transform.position = offscreenLocation.transform.position;

		roleList = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetAssignedRoleNames(); //list of all roles that have been assigned to players in game

		float duration = 5f;
		StartCoroutine(StartNight(duration));
	}

	public void ChangeRole() //runs every time the done button is hit to change to next role
	{
		print("RUNNING");
		if (currentRole == "poisoner")
		{
			Scroll.transform.position = offscreenLocation.transform.position;
			Spy();
		}
		else
		if (currentRole == "spy")
		{
			spyPlayerButton.gameObject.SetActive(false);
			spyTownButton.gameObject.SetActive(false);
			spyOutsiderButton.gameObject.SetActive(false);
			spyEvilButton.gameObject.SetActive(false);
			infoText.text = "";
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
		else
		if (currentRole == "chef")
		{
			infoText.text = "";
			infoText.gameObject.transform.position = onscreenLocation.transform.position;
			Empath();
		}
		else
		if (currentRole == "empath")
		{
			infoText.text = "";
			Scroll.transform.position = onscreenLocation.transform.position;
			infoText.gameObject.transform.position = offscreenLocation.transform.position;
			FortuneTeller();
		}
		else
		if (currentRole == "fortuneteller")
		{
			//wait a sec so FT can see answer.
			StartCoroutine(waitFT(5f));
			//Scroll.transform.position = onscreenLocation.transform.position;
			//Butler();
		}
		else
		if (currentRole == "butler")
		{
			infoText.text = "";
			if (butlerDone == true)
			{
				Debug.Log("GOOD MORNING");
				DoneButton.GetComponent<ChangeScene>().Day();
			}
		}
		Debug.Log("current role:" + currentRole.ToString());
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

	IEnumerator waitFT(float duration)
	{
		infoText.gameObject.transform.position = onscreenLocation.transform.position;
		Scroll.transform.position = offscreenLocation.transform.position;
		Debug.Log("waiting FT");
		gameText.text = "Displaying FT info.";
		yield return new WaitForSeconds(duration);
		Scroll.transform.position = onscreenLocation.transform.position;
		infoText.gameObject.transform.position = offscreenLocation.transform.position;
		Butler();
	}



	IEnumerator Minions(float delay) //time for minions to see each other (only if 7 or more players)
	{
		gameText.text = "minions do ur thing (big game)";
		Debug.Log($"Started at {Time.time}");
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Demon)
			{
				gameText.text = x.playerName.ToString() + " is the demon.";
			}
		}
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
		gameText.text = "Minions: ";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Minion)
			{
				gameText.text +=  x.playerName.ToString() + " ";
			}
		}
		List<CharacterLibrary.CharacterRole> bluffRoles = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetDemonBluffRoles();
		string bluffNames = string.Join(", ", bluffRoles.ConvertAll(role => role.characterName));
		gameText.text += "\nBluffs: " + bluffNames;
		yield return new WaitForSeconds(5);
		Debug.Log($"Ended at {Time.time}");
		gameText.text = "Timer done.";
		//minions put thumbs down
		//demon sees 3 good-aligned roles that no one has been assigned
		//whatever thing has demons sleep here.
		Poisoner();
	}

	public void Poisoner()
	{
		Scroll.transform.position = onscreenLocation.transform.position;
		currentRole = "poisoner";
		gameText.text = "poisoner do ur thing";
		//method for this is in ToggleListPopulator
	}

	public void Spy()
	{
		infoText.gameObject.transform.position = onscreenLocation.transform.position;
		currentRole = "spy";
		gameText.text = "spy do ur thing";
		spyPlayerButton.gameObject.SetActive(true);
		spyTownButton.gameObject.SetActive(true);
		spyOutsiderButton.gameObject.SetActive(true);
		spyEvilButton.gameObject.SetActive(true);
	}

	public void SpyPlayerInfo()
	{
		infoText.text = "";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		foreach (Player x in allPlayers)
		{
			infoText.text += x.playerName.ToString() + " is the " + x.characterName.ToString() + ". \n";
		}
	}

	public void SpyEvilInfo()
	{
		infoText.text = "";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();

		foreach (Player x in allPlayers)
		{
			Debug.Log($"{x.playerName} poisoned status: {x.isPoisoned}"); 
			if (x.isPoisoned)
			{
				infoText.text += x.playerName.ToString() + " is poisoned.\n";
			}
		}
	}

	public void SpyOutsiderInfo()
	{
		infoText.text = "";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		foreach (Player x in allPlayers)
		{
			if (x.isMaster == true)
			{
				infoText.text += x.playerName.ToString() + " is the Butler's Master.";
			}
		}
	}

	public void SpyTownInfo()
	{
		infoText.text = "";
		Debug.Log("info here.");
	}

	public void Washerwoman()
	{
		infoText.gameObject.transform.position = onscreenLocation.transform.position;
		currentRole = "washerwoman";
		gameText.text = "washerwoman do ur thing";


		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		List<Player> allTown = new List<Player>();

		foreach (Player x in allPlayers)
		{
			//find who is washerwoman and see if they are poisoned
			if (x.characterName == "Washerwoman")
			{
				Debug.Log(x.playerName + " is the Washerwoman.");
				if (x.isPoisoned ==  true)
				{
					Debug.Log(x.playerName + " is poisoned.");
					currentPoisoned = true;
				}
			}
		}

		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Townsfolk && x.characterName != "Washerwoman")
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

		if (currentPoisoned == true) //if washerwoman is poisoned
		{
			string poisonName = "";
			int prandom = 0;

			while (poisonName == "" || poisonName == "Washerwoman")
			{
				prandom = Random.Range(0, townsfolkRoles.Count);
				poisonName = townsfolkRoles[prandom].characterName;
			}

			Debug.Log("poison role: " + poisonName);

			//randomize the order the two names are shown
			Player roleShownAs;
			Player other;

			if (Random.value < 0.5f)
			{
				roleShownAs = selectedTown;   // True Townsfolk
				other = selectedRandom;       // Decoy
			}
			else
			{
				roleShownAs = selectedRandom;  // Decoy
				other = selectedTown;          // True Townsfolk
			}

			// Show info to player
			string role = poisonName.ToString();
			infoText.text += "Either " + roleShownAs.playerName + " or " + other.playerName + " is the " + role + ".";
			currentPoisoned = false;
		}
		else
		{
			//randomize the order the two names are shown
			Player roleShownAs;
			Player other;

			if (Random.value < 0.5f)
			{
				roleShownAs = selectedTown;   // True Townsfolk
				other = selectedRandom;       // Decoy
			}
			else
			{
				roleShownAs = selectedRandom;  // Decoy
				other = selectedTown;          // True Townsfolk
			}

			// Show info to player
			string role = selectedTown.characterName;
			infoText.text += "Either " + roleShownAs.playerName + " or " + other.playerName + " is the " + role + ".";
		}
	}

	public void Librarian()
	{
		currentRole = "librarian";
		gameText.text = "librarian do ur thing";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		List<Player> allOutsiders = new List<Player>();

		foreach (Player x in allPlayers)
		{
			//find who is librarian and see if they are poisoned
			if (x.characterName == "Librarian")
			{
				Debug.Log(x.playerName + " is the Librarian.");
				if (x.isPoisoned == true)
				{
					Debug.Log(x.playerName + " is poisoned.");
					currentPoisoned = true;
				}
			}
		}

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
			Player selectedOutsider = null;
			Player selectedRandom = null;

			if (currentPoisoned)
			{
				// Pick from all players
				int random = Random.Range(0, allPlayers.Count);
				selectedOutsider = allPlayers[random];
				int random2 = Random.Range(0, allPlayers.Count);
				selectedRandom = allPlayers[random2];

				while (selectedOutsider == selectedRandom || selectedOutsider.characterName == "Librarian" || selectedRandom.characterName == "Librarian")
				{
					random = Random.Range(0, allPlayers.Count);
					selectedOutsider = allPlayers[random];
					random2 = Random.Range(0, allPlayers.Count);
					selectedRandom = allPlayers[random2];
				}
			}
			else
			{
				// Pick true outsider
				int random = Random.Range(0, allOutsiders.Count);
				selectedOutsider = allOutsiders[random];
				int random2 = Random.Range(0, allPlayers.Count);
				selectedRandom = allPlayers[random2];

				while (selectedOutsider == selectedRandom || selectedOutsider.characterName == "Librarian" || selectedRandom.characterName == "Librarian")
				{
					random = Random.Range(0, allOutsiders.Count);
					selectedOutsider = allOutsiders[random];
					random2 = Random.Range(0, allPlayers.Count);
					selectedRandom = allPlayers[random2];
				}
			}

			Debug.Log("Selected Outsider: " + selectedOutsider.playerName + " is the " + selectedOutsider.characterName);
			Debug.Log("Selected Random: " + selectedRandom.playerName + " is the " + selectedRandom.characterName);

			Player roleShownAs;
			Player other;

			if (Random.value < 0.5f)
			{
				roleShownAs = selectedOutsider;
				other = selectedRandom;
			}
			else
			{
				roleShownAs = selectedRandom;
				other = selectedOutsider;
			}

			string role;

			if (currentPoisoned)
			{
				// Show incorrect outsider role
				string poisonName = "";
				int prandom = 0;

				while (poisonName == "" || poisonName == "Librarian")
				{
					prandom = Random.Range(0, outsiderRoles.Count);
					poisonName = outsiderRoles[prandom].characterName;
				}

				Debug.Log("Poisoned: showing false role " + poisonName);
				role = poisonName;
				currentPoisoned = false;
			}
			else
			{
				role = selectedOutsider.characterName;
			}

			infoText.text += "Either " + roleShownAs.playerName + " or " + other.playerName + " is the " + role + ".";
		}

	}

	public void Investigator()
	{
		currentRole = "investigator";
		gameText.text = "investigator do ur thing";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		List<Player> allMinions = new List<Player>();

		// Check if Investigator is poisoned
		foreach (Player x in allPlayers)
		{
			if (x.characterName == "Investigator")
			{
				Debug.Log(x.playerName + " is the Investigator.");
				if (x.isPoisoned)
				{
					Debug.Log(x.playerName + " is poisoned.");
					currentPoisoned = true;
				}
			}
		}

		// Build list of Minions
		foreach (Player x in allPlayers)
		{
			if (x.alignment == CharacterLibrary.Alignment.Minion)
			{
				allMinions.Add(x);
			}
		}

		if (allMinions.Count == 0 && !currentPoisoned)
		{
			infoText.text += "There are no Minions!";
		}
		else
		{
			Player selectedMinion = null;
			Player selectedRandom = null;

			if (currentPoisoned)
			{
				// Choose from all players
				int random = Random.Range(0, allPlayers.Count);
				selectedMinion = allPlayers[random];
				int random2 = Random.Range(0, allPlayers.Count);
				selectedRandom = allPlayers[random2];

				while (selectedMinion == selectedRandom || selectedMinion.characterName == "Investigator" || selectedRandom.characterName == "Investigator")
				{
					random = Random.Range(0, allPlayers.Count);
					selectedMinion = allPlayers[random];
					random2 = Random.Range(0, allPlayers.Count);
					selectedRandom = allPlayers[random2];
				}
				currentPoisoned = false;
			}
			else
			{
				// Choose real minion and random other
				int random = Random.Range(0, allMinions.Count);
				selectedMinion = allMinions[random];
				int random2 = Random.Range(0, allPlayers.Count);
				selectedRandom = allPlayers[random2];

				while (selectedMinion == selectedRandom || selectedMinion.characterName == "Investigator" || selectedRandom.characterName == "Investigator")
				{
					random = Random.Range(0, allMinions.Count);
					selectedMinion = allMinions[random];
					random2 = Random.Range(0, allPlayers.Count);
					selectedRandom = allPlayers[random2];
				}
			}

			Debug.Log("Selected Minion: " + selectedMinion.playerName + " is the " + selectedMinion.characterName);
			Debug.Log("Selected Random: " + selectedRandom.playerName + " is the " + selectedRandom.characterName);

			Player roleShownAs;
			Player other;
			if (Random.value < 0.5f)
			{
				roleShownAs = selectedMinion;
				other = selectedRandom;
			}
			else
			{
				roleShownAs = selectedRandom;
				other = selectedMinion;
			}

			string role;
			if (currentPoisoned)
			{
				// Choose a random fake minion role
				string poisonName = "";
				int prandom = 0;
				while (poisonName == "" || poisonName == "Investigator")
				{
					prandom = Random.Range(0, minionRoles.Count);
					poisonName = minionRoles[prandom].characterName;
				}
				Debug.Log("Poisoned: showing false role " + poisonName);
				role = poisonName;
				currentPoisoned = false;
			}
			else
			{
				role = selectedMinion.characterName;
			}

			infoText.text += "Either " + roleShownAs.playerName + " or " + other.playerName + " is the " + role + ".";
		}
		currentPoisoned = false;
	}

	public void Chef()
	{
		currentRole = "chef";
		gameText.text = "chef do ur thing";
		//Shows 0, 1, 2, etc for # of evil players sitting next to each other (counts first and last position as sitting next to each other
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		int chefCounter = 0;

		// Check if Chef is poisoned
		foreach (Player x in allPlayers)
		{
			if (x.characterName == "Chef")
			{
				Debug.Log(x.playerName + " is the Chef.");
				if (x.isPoisoned)
				{
					Debug.Log(x.playerName + " is poisoned.");
					currentPoisoned = true;
				}
			}
		}


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

		if (currentPoisoned ==  true)
		{
			chefCounter = Random.Range(0, 2);
		}
		if (chefCounter == 1)
		{
			infoText.text += "There is " + chefCounter.ToString() + " pair of evil players sitting next to each other.";
		}
		else
		{
			infoText.text += "There are " + chefCounter.ToString() + " pairs of evil players sitting next to each other.";
		}

		currentPoisoned = false;
	}

	public void Empath()
	{
		int currentisEmpath = 0;
		//Shows 0, 1, 2, etc for # of evil players sitting next to empath
		//don't need to skip dead players cause night 1
		currentRole = "empath";
		gameText.text = "empath do ur thing";
		List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
		int empathCounter = 0;


		// Check if Empath is poisoned
		foreach (Player x in allPlayers)
		{
			if (x.characterName == "Empath")
			{
				Debug.Log(x.playerName + " is the Empath.");
				if (x.isPoisoned)
				{
					Debug.Log(x.playerName + " is poisoned.");
					currentPoisoned = true;
				}
			}
		}

		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].characterName.ToLower() == "empath")
			{
				currentisEmpath = i;
			}
		}
		Debug.Log(allPlayers[currentisEmpath].ToString() + " is the Empath.");

		Debug.Log(allPlayers[(currentisEmpath - 1 + allPlayers.Count) % allPlayers.Count].characterName +
			" is " + allPlayers[(currentisEmpath - 1 + allPlayers.Count) % allPlayers.Count].alignment +
			" and is 1 before empath");

		Debug.Log(allPlayers[(currentisEmpath + 1) % allPlayers.Count].characterName +
			" is " + allPlayers[(currentisEmpath + 1) % allPlayers.Count].alignment +
			" and is 1 after empath");


		int beforeIndex = (currentisEmpath - 1 + allPlayers.Count) % allPlayers.Count;
		int afterIndex = (currentisEmpath + 1) % allPlayers.Count;

		if (allPlayers[beforeIndex].alignment == CharacterLibrary.Alignment.Demon ||
			allPlayers[beforeIndex].alignment == CharacterLibrary.Alignment.Minion)
		{
			empathCounter++;
		}

		if (allPlayers[afterIndex].alignment == CharacterLibrary.Alignment.Demon ||
			allPlayers[afterIndex].alignment == CharacterLibrary.Alignment.Minion)
		{
			empathCounter++;
		}

		if (currentPoisoned == true)
		{
			empathCounter = Random.Range(0, 2);
		}
		if (empathCounter == 1)
		{
			infoText.text += "There is one evil player sitting next to you.";
		}
		else
		{
			infoText.text += "There are " + empathCounter.ToString() + " evil players sitting next to you.";
		}
		currentPoisoned = false;
	}

	public void FortuneTeller()
	{
		currentRole = "fortuneteller";
		gameText.text = "fortune teller do ur thing";
		//method for this is in ToggleListPopulator

	}

	public void Butler()
	{
		currentRole = "butler";
		gameText.text = "butler do ur thing";
		//method for this is in ToggleListPopulator
	}
}
