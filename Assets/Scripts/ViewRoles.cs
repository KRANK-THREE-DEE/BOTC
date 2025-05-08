using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewRoles : MonoBehaviour
{
    public Button closeButton;

	public int buttonActivateCount;

    public Transform gridParent;
    public int numberofButtons;

    public GameObject buttonPrefab;
	void Start()
	{
		AssignCharacters.Instance.gameObject.SetActive(true);
		int i = 0;
		foreach (var player in GameManager.Instance.playerOrder)
		{
			GameObject newButton = Instantiate(buttonPrefab, gridParent);
			RectTransform rt = newButton.GetComponent<RectTransform>();
			if (rt != null)
			{
				rt.sizeDelta = new Vector2(200, 100); // Width x Height
			}

			TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
			if (buttonText != null)
			{
				buttonText.text = player.playerName; 
			}
			else
			{
				Debug.LogWarning("No TMP_Text found on button prefab.");
			}
			i++;
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }





}
