using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerNumber : MonoBehaviour
{
	public TextMeshProUGUI playerNumberText;

	void Start()
	{
		playerNumberText.text = "Number of players: " + GameManager.playerNumber.ToString();
	}

}
