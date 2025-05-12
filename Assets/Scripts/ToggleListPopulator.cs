using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Data;
using JetBrains.Annotations;

public class ToggleListPopulator : MonoBehaviour
{
	public GameObject togglePrefab;
	public Transform contentParent;

	private List<Toggle> toggleList = new List<Toggle>();
	private NightOne nightOneScript;

	void Start()
	{
		nightOneScript = GetComponent<NightOne>();
		PopulateToggleList();
	}

	void PopulateToggleList()
	{
		// Clear old toggles
		foreach (Transform child in contentParent)
		{
			Destroy(child.gameObject);
		}
		toggleList.Clear();

		for (int i = 0; i < GameManager.Instance.playerNumber; i++)
		{
			GameObject toggleObj = Instantiate(togglePrefab, contentParent);
			Toggle toggle = toggleObj.GetComponent<Toggle>();
			Text label = toggleObj.GetComponentInChildren<Text>();

			if (label != null && i < GameManager.Instance.playerOrder.Count)
			{
				label.text = GameManager.Instance.playerOrder[i].playerName;
			}

			// Add the onValueChanged listener
			int index = i; 
			toggle.onValueChanged.AddListener((isOn) => OnToggleChanged(toggle, isOn, index)); //tells toggles to run OnToggleChanged when toggled

			toggleList.Add(toggle);
		}
	}

	void OnToggleChanged(Toggle changedToggle, bool isOn, int index) //used to keep poisoner from selecting multiple people
	{
		if (nightOneScript.currentRole == "poisoner" && isOn || nightOneScript.currentRole == "butler" && isOn)
		{
			// Only allow one toggle
			foreach (var toggle in toggleList)
			{
				if (toggle != changedToggle)
				{
					toggle.isOn = false;
				}
			}
		}
		else if (nightOneScript.currentRole == "fortuneteller")
		{
			int activeCount = 0;
			foreach (var toggle in toggleList)
			{
				if (toggle.isOn) activeCount++;
			}

			// If this makes 3 toggles on, turn it back off
			if (activeCount > 2)
			{
				changedToggle.isOn = false;
			}
		}
	}

	public void OnConfirmSelection()
	{
		string selectedName = "";
		string selectedName2 = "";
		int selectedNameIndex = 0;
		int selectedNameIndex2 = 0;

		for (int i = 0; i < toggleList.Count; i++)
		{
			if (toggleList[i].isOn)
			{
				if (selectedName == "")
				{
					selectedName = GameManager.Instance.playerOrder[i].playerName;
					selectedNameIndex = i;
				}
				else
				{
					selectedName2 = GameManager.Instance.playerOrder[i].playerName;
					selectedNameIndex2 = i;
				}
			}
		}

		if (nightOneScript.currentRole == "poisoner")
		{
			if (selectedName != "")
			{
				Debug.Log("Poisoner selected: " + selectedName);
				Player selectedPlayer = GameManager.Instance.playerOrder[selectedNameIndex];
				selectedPlayer.isPoisoned = true;
				Debug.Log($"{selectedPlayer.playerName} has been poisoned!");
			}
		}
		else if (nightOneScript.currentRole == "fortuneteller")
		{
			List<Player> allPlayers = AssignCharacters.Instance.GetComponent<AssignCharacters>().GetPlayers();
			foreach (Player x in allPlayers)
			{
				//find who is librarian and see if they are poisoned
				if (x.characterName == "Fortune Teller")
				{
					Debug.Log(x.playerName + " is the Fortune Teller.");
					if (x.isPoisoned == true)
					{
						Debug.Log(x.playerName + " is poisoned.");
						nightOneScript.currentPoisoned = true;
					}
				}
			}
			if (selectedName != "" && selectedName2 != "")
			{
				Player selectedPlayer = GameManager.Instance.playerOrder[selectedNameIndex];
				Player selectedPlayer2 = GameManager.Instance.playerOrder[selectedNameIndex2];
				Debug.Log("FT pick 1 is " + selectedPlayer.playerName + ", who is a " + selectedPlayer.alignment);
				Debug.Log("FT pick 2 is " + selectedPlayer2.playerName + ", who is a " + selectedPlayer2.alignment);
				if (nightOneScript.currentPoisoned == true)
				{
					nightOneScript.infoText.gameObject.transform.position = nightOneScript.onscreenLocation.transform.position;
					int x = Random.Range(0, 2);
					if (x == 0)
					{
						Debug.Log("Poisoned: Yes.");
						nightOneScript.infoText.text = "Fortune Teller Answer: Yes.";
					}
					else
					{
						Debug.Log("Poisoned: No.");
						nightOneScript.infoText.text = "Fortune Teller Answer: No.";
					}
					nightOneScript.currentPoisoned = false;
				}
				else
				if (selectedPlayer.alignment == CharacterLibrary.Alignment.Demon || selectedPlayer2.alignment == CharacterLibrary.Alignment.Demon)
				{
					nightOneScript.infoText.gameObject.transform.position = nightOneScript.onscreenLocation.transform.position;
					nightOneScript.infoText.text = "Fortune Teller Answer: Yes.";
					Debug.Log("Nonpoisoned: Yes.");
				}
				else
				{
					nightOneScript.infoText.gameObject.transform.position = nightOneScript.onscreenLocation.transform.position;
					nightOneScript.infoText.text = "Fortune Teller Answer: No.";
					Debug.Log("Nonpoisoned: No.");
				}
			}
			else
			{
				Debug.Log("FT needs to pick 2 people.");
			}
		}
		else
		if (nightOneScript.currentRole == "butler")
		{
			if (selectedName != "")
			{
				Debug.Log("Butler selected: " + selectedName);
				Player selectedPlayer = GameManager.Instance.playerOrder[selectedNameIndex];
				selectedPlayer.isMaster = true;
				Debug.Log($"{selectedPlayer.playerName} has been chosen by Butler!");
				nightOneScript.butlerDone = true;
			}
		}
		foreach (var toggle in toggleList)
		{
			toggle.isOn = false;
		}
	}
}
