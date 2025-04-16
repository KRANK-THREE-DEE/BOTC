using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ToggleListPopulator : MonoBehaviour
{
	public GameObject togglePrefab;           // Drag your Toggle prefab here
	public Transform contentParent;           // The Content object of your Scroll View

	void Start()
	{
		PopulateToggleList();
	}

	void PopulateToggleList()
	{
		// Clear old toggles if any
		foreach (Transform child in contentParent)
		{
			Destroy(child.gameObject);
		}

		for (int i = 0; i < GameManager.Instance.playerNumber; i++)
		{
			GameObject toggleObj = Instantiate(togglePrefab, contentParent);
			Toggle toggle = toggleObj.GetComponent<Toggle>();
			Text label = toggleObj.GetComponentInChildren<Text>();

			if (label != null && i < GameManager.Instance.playerOrder.Count)
			{
				label.text = GameManager.Instance.playerOrder[i].playerName;
			}

		}
	}
}
