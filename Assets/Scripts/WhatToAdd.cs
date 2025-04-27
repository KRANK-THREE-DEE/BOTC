using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WhatToAdd : MonoBehaviour
{
	public int minionNumber;
	public int townNumber;
	public int outsiderNumber;
	public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
		SetCharacterNumber();
    }

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

	public void Text()
	{
		text.text = "";
		text.text += "There are " + GameManager.Instance.playerNumber.ToString() + " players in game.\n";
		text.text += "There is 1 <b><color=#FF0000>Demon</color></b> in game.\n";
		text.text += "There should be " + townNumber.ToString() + " <b><color=#00AEFF>Town</color></b> in game.\n";
		text.text += "There should be " + outsiderNumber.ToString() + " <b><color=#7C00FF>Outsiders</color></b> in game.\n";
		text.text += "There should be " + minionNumber.ToString() + " <b><color=#FF3600>Minions</color></b> in game.\n";
	}

}
