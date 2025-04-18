using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ToggleListPopulator : MonoBehaviour
{
	public GameObject togglePrefab;
	public Transform contentParent;

	// Store toggle and player reference
	private List<Toggle> toggleList = new List<Toggle>();

	void Start()
	{
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

			toggleList.Add(toggle);
		}
	}

	// Call from done button
	public void OnConfirmSelection()
	{
		NightOne nightOneScript = GetComponent<NightOne>(); // since both are on the same object
		string selectedName = "";
		string selectedName2 = "";
		int selectedNameIndex = 0;
		int selectedNameIndex2 = 0;
		for (int i = 0; i < toggleList.Count; i++) 
		{
			if (toggleList[i].isOn)
			{
				if(selectedName == "")
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
			Debug.Log("Poisoner selected: " + selectedName);
			Player selectedPlayer = GameManager.Instance.playerOrder[selectedNameIndex];
			selectedPlayer.isPoisoned = true;

			Debug.Log($"{selectedPlayer.playerName} has been poisoned!");
			selectedName = "";
			selectedName2 = "";
		}
		else
		if (nightOneScript.currentRole == "fortuneteller")
		{
			if (selectedName != "" && selectedName2 != "")
			{
				Player selectedPlayer = GameManager.Instance.playerOrder[selectedNameIndex];
				Player selectedPlayer2 = GameManager.Instance.playerOrder[selectedNameIndex2];
				Debug.Log("FT pick 1 is " + selectedPlayer.playerName.ToString() + ", who is a " + selectedPlayer.alignment.ToString());
				Debug.Log("FT pick 2 is " + selectedPlayer2.playerName.ToString() + ", who is a " + selectedPlayer2.alignment.ToString());
				if (selectedPlayer.alignment == CharacterLibrary.Alignment.Demon || (selectedPlayer2.alignment == CharacterLibrary.Alignment.Demon))
				{
					Debug.Log("Yes.");
				}
				else
				{
					Debug.Log("No.");
				}
			}
			else
			{
				Debug.Log("FT needs to pick 2 people."); //works!
			}
		}
	}
}
