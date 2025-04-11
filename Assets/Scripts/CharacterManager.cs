using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
	public static bool impAvailable;
	public static bool poisonerAvailable;
	public static bool spyAvailable;
	public static bool scarletWomanAvailable;
	public static bool baronAvailable;
	public static bool butlerAvailable;
	public static bool recluseAvailable;
	public static bool drunkAvailable;
	public static bool saintAvailable;
	public static bool washerwomanAvailable;
	public static bool librarianAvailable;
	public static bool investigatorAvailable;
	public static bool chefAvailable;
	public static bool empathAvailable;
	public static bool fortuneTellerAvailable;
	public static bool undertakerAvailable;
	public static bool monkAvailable;
	public static bool ravenkeeperAvailable;
	public static bool virginAvailable;
	public static bool slayerAvailable;
	public static bool soldierAvailable;
	public static bool mayorAvailable;

	public Toggle impToggle;
	public Toggle poisonerToggle;
	public Toggle spyToggle;
	public Toggle scarletWomanToggle;
	public Toggle baronToggle;
	public Toggle butlerToggle;
	public Toggle recluseToggle;
	public Toggle drunkToggle;
	public Toggle saintToggle;
	public Toggle washerwomanToggle;
	public Toggle librarianToggle;
	public Toggle investigatorToggle;
	public Toggle chefToggle;
	public Toggle empathToggle;
	public Toggle fortuneTellerToggle;
	public Toggle undertakerToggle;
	public Toggle monkToggle;
	public Toggle ravenkeeperToggle;
	public Toggle virginToggle;
	public Toggle slayerToggle;
	public Toggle soldierToggle;
	public Toggle mayorToggle;

	public bool SelectAllHit;

	private void Start()
	{
		// Initialize most roles as false (not available)
		impAvailable = true;
		poisonerAvailable = false;
		spyAvailable = false;
		scarletWomanAvailable = false;
		baronAvailable = false;
		butlerAvailable = false;
		recluseAvailable = false;
		drunkAvailable = false;
		saintAvailable = false;
		washerwomanAvailable = false;
		librarianAvailable = false;
		investigatorAvailable = false;
		chefAvailable = false;
		empathAvailable = false;
		fortuneTellerAvailable = false;
		undertakerAvailable = false;
		monkAvailable = false;
		ravenkeeperAvailable = false;
		virginAvailable = false;
		slayerAvailable = false;
		soldierAvailable = false;
		mayorAvailable = false;
	}

	// Toggle the roles based on the button clicked
	public void ToggleRole(GameObject thisObject)
	{
		string roleName = thisObject.GetComponentInChildren<Text>().text;

		if (SelectAllHit == false)
		{
			switch (roleName)
			{
				case "Imp":
					impAvailable = !impAvailable;
					break;
				case "Poisoner":
					poisonerAvailable = !poisonerAvailable;
					break;
				case "Spy":
					spyAvailable = !spyAvailable;
					break;
				case "Scarlet Woman":
					scarletWomanAvailable = !scarletWomanAvailable;
					break;
				case "Baron":
					baronAvailable = !baronAvailable;
					break;
				case "Butler":
					butlerAvailable = !butlerAvailable;
					break;
				case "Recluse":
					recluseAvailable = !recluseAvailable;
					break;
				case "Drunk":
					drunkAvailable = !drunkAvailable;
					break;
				case "Saint":
					saintAvailable = !saintAvailable;
					break;
				case "Washerwoman":
					washerwomanAvailable = !washerwomanAvailable;
					break;
				case "Librarian":
					librarianAvailable = !librarianAvailable;
					break;
				case "Investigator":
					investigatorAvailable = !investigatorAvailable;
					break;
				case "Chef":
					chefAvailable = !chefAvailable;
					break;
				case "Empath":
					empathAvailable = !empathAvailable;
					break;
				case "Fortune Teller":
					fortuneTellerAvailable = !fortuneTellerAvailable;
					break;
				case "Undertaker":
					undertakerAvailable = !undertakerAvailable;
					break;
				case "Monk":
					monkAvailable = !monkAvailable;
					break;
				case "Ravenkeeper":
					ravenkeeperAvailable = !ravenkeeperAvailable;
					break;
				case "Virgin":
					virginAvailable = !virginAvailable;
					break;
				case "Slayer":
					slayerAvailable = !slayerAvailable;
					break;
				case "Soldier":
					soldierAvailable = !soldierAvailable;
					break;
				case "Mayor":
					mayorAvailable = !mayorAvailable;
					break;
				default:
					Debug.LogWarning("Role not found: " + roleName);
					break;
			}
		}
	}

	public void SelectAll()
	{
		SelectAllHit = true;
		impAvailable = true;
		impToggle.isOn = true;
		poisonerAvailable = true;
		poisonerToggle.isOn = true;
		spyAvailable = true;
		spyToggle.isOn = true;
		scarletWomanAvailable = true;
		scarletWomanToggle.isOn = true;
		baronAvailable = true;
		baronToggle.isOn = true;
		butlerAvailable = true;
		butlerToggle.isOn = true;
		recluseAvailable = true;
		recluseToggle.isOn = true;
		drunkAvailable = true;
		drunkToggle.isOn = true;
		saintAvailable = true;
		saintToggle.isOn = true;
		washerwomanAvailable = true;
		washerwomanToggle.isOn = true;
		librarianAvailable = true;
		librarianToggle.isOn = true;
		investigatorAvailable = true;
		investigatorToggle.isOn = true;
		chefAvailable = true;
		chefToggle.isOn = true;
		empathAvailable = true;
		empathToggle.isOn = true;
		fortuneTellerAvailable = true;
		fortuneTellerToggle.isOn = true;
		undertakerAvailable = true;
		undertakerToggle.isOn = true;
		monkAvailable = true;
		monkToggle.isOn = true;
		ravenkeeperAvailable = true;
		ravenkeeperToggle.isOn = true;
		virginAvailable = true;
		virginToggle.isOn = true;
		slayerAvailable = true;
		slayerToggle.isOn = true;
		soldierAvailable = true;
		soldierToggle.isOn = true;
		mayorAvailable = true;
		mayorToggle.isOn = true;
		SelectAllHit = false;
	}

	public void DeselectAll()
	{
		SelectAllHit = true;
		poisonerAvailable = false;
		poisonerToggle.isOn = false;
		spyAvailable = false;
		spyToggle.isOn = false;
		scarletWomanAvailable = false;
		scarletWomanToggle.isOn = false;
		baronAvailable = false;
		baronToggle.isOn = false;
		butlerAvailable = false;
		butlerToggle.isOn = false;
		recluseAvailable = false;
		recluseToggle.isOn = false;
		drunkAvailable = false;
		drunkToggle.isOn = false;
		saintAvailable = false;
		saintToggle.isOn = false;
		washerwomanAvailable = false;
		washerwomanToggle.isOn = false;
		librarianAvailable = false;
		librarianToggle.isOn = false;
		investigatorAvailable = false;
		investigatorToggle.isOn = false;
		chefAvailable = false;
		chefToggle.isOn = false;
		empathAvailable = false;
		empathToggle.isOn = false;
		fortuneTellerAvailable = false;
		fortuneTellerToggle.isOn = false;
		undertakerAvailable = false;
		undertakerToggle.isOn = false;
		monkAvailable = false;
		monkToggle.isOn = false;
		ravenkeeperAvailable = false;
		ravenkeeperToggle.isOn = false;
		virginAvailable = false;
		virginToggle.isOn = false;
		slayerAvailable = false;
		slayerToggle.isOn = false;
		soldierAvailable = false;
		soldierToggle.isOn = false;
		mayorAvailable = false;
		mayorToggle.isOn = false;
		SelectAllHit = false;
	}
}
