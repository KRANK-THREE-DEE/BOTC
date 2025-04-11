using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNumberSlider : MonoBehaviour
{
	public Slider slider;
	public TextMeshProUGUI playerNumberText;
	//public static int playerNumber;

	public void Start()
	{
		GameManager.playerNumber = 5;
	}
	public void ChangeNumber()
	{
		playerNumberText.text = slider.value.ToString();
		GameManager.playerNumber = (int)slider.value;

	}
}
