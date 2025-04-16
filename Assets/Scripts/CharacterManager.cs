using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
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
	public List<CharacterLibrary.CharacterRole> AvailableRoles = new List<CharacterLibrary.CharacterRole>();

	private void Start()
	{

	}

	public void ToggleCharacter(GameObject thisObject)
	{
		string roleName = thisObject.GetComponentInChildren<Text>().text;

		if (SelectAllHit == false)
		{
			switch (roleName)
			{
				case "Imp":
					GameManager.Instance.impAvailable = !GameManager.Instance.impAvailable;
					break;
				case "Poisoner":
					GameManager.Instance.poisonerAvailable = !GameManager.Instance.poisonerAvailable;
					break;
				case "Spy":
					GameManager.Instance.spyAvailable = !GameManager.Instance.spyAvailable;
					break;
				case "Scarlet Woman":
					GameManager.Instance.scarletWomanAvailable = !GameManager.Instance.scarletWomanAvailable;
					break;
				case "Baron":
					GameManager.Instance.baronAvailable = !GameManager.Instance.baronAvailable;
					break;
				case "Butler":
					GameManager.Instance.butlerAvailable = !GameManager.Instance.butlerAvailable;
					break;
				case "Recluse":
					GameManager.Instance.recluseAvailable = !GameManager.Instance.recluseAvailable;
					break;
				case "Drunk":
					GameManager.Instance.drunkAvailable = !GameManager.Instance.drunkAvailable;
					break;
				case "Saint":
					GameManager.Instance.saintAvailable = !GameManager.Instance.saintAvailable;
					break;
				case "Washerwoman":
					GameManager.Instance.washerwomanAvailable = !GameManager.Instance.washerwomanAvailable;
					break;
				case "Librarian":
					GameManager.Instance.librarianAvailable = !GameManager.Instance.librarianAvailable;
					break;
				case "Investigator":
					GameManager.Instance.investigatorAvailable = !GameManager.Instance.investigatorAvailable;
					break;
				case "Chef":
					GameManager.Instance.chefAvailable = !GameManager.Instance.chefAvailable;
					break;
				case "Empath":
					GameManager.Instance.empathAvailable = !GameManager.Instance.empathAvailable;
					break;
				case "Fortune Teller":
					GameManager.Instance.fortuneTellerAvailable = !GameManager.Instance.fortuneTellerAvailable;
					break;
				case "Undertaker":
					GameManager.Instance.undertakerAvailable = !GameManager.Instance.undertakerAvailable;
					break;
				case "Monk":
					GameManager.Instance.monkAvailable = !GameManager.Instance.monkAvailable;
					break;
				case "Ravenkeeper":
					GameManager.Instance.ravenkeeperAvailable = !GameManager.Instance.ravenkeeperAvailable;
					break;
				case "Virgin":
					GameManager.Instance.virginAvailable = !GameManager.Instance.virginAvailable;
					break;
				case "Slayer":
					GameManager.Instance.slayerAvailable = !GameManager.Instance.slayerAvailable;
					break;
				case "Soldier":
					GameManager.Instance.soldierAvailable = !GameManager.Instance.soldierAvailable;
					break;
				case "Mayor":
					GameManager.Instance.mayorAvailable = !GameManager.Instance.mayorAvailable;
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

		GameManager.Instance.impAvailable = impToggle.isOn = true;
		GameManager.Instance.poisonerAvailable = poisonerToggle.isOn = true;
		GameManager.Instance.spyAvailable = spyToggle.isOn = true;
		GameManager.Instance.scarletWomanAvailable = scarletWomanToggle.isOn = true;
		GameManager.Instance.baronAvailable = baronToggle.isOn = true;
		GameManager.Instance.butlerAvailable = butlerToggle.isOn = true;
		GameManager.Instance.recluseAvailable = recluseToggle.isOn = true;
		GameManager.Instance.drunkAvailable = drunkToggle.isOn = true;
		GameManager.Instance.saintAvailable = saintToggle.isOn = true;
		GameManager.Instance.washerwomanAvailable = washerwomanToggle.isOn = true;
		GameManager.Instance.librarianAvailable = librarianToggle.isOn = true;
		GameManager.Instance.investigatorAvailable = investigatorToggle.isOn = true;
		GameManager.Instance.chefAvailable = chefToggle.isOn = true;
		GameManager.Instance.empathAvailable = empathToggle.isOn = true;
		GameManager.Instance.fortuneTellerAvailable = fortuneTellerToggle.isOn = true;
		GameManager.Instance.undertakerAvailable = undertakerToggle.isOn = true;
		GameManager.Instance.monkAvailable = monkToggle.isOn = true;
		GameManager.Instance.ravenkeeperAvailable = ravenkeeperToggle.isOn = true;
		GameManager.Instance.virginAvailable = virginToggle.isOn = true;
		GameManager.Instance.slayerAvailable = slayerToggle.isOn = true;
		GameManager.Instance.soldierAvailable = soldierToggle.isOn = true;
		GameManager.Instance.mayorAvailable = mayorToggle.isOn = true;

		SelectAllHit = false;
	}

	public void DeselectAll()
	{
		SelectAllHit = true;

		GameManager.Instance.impAvailable = impToggle.isOn = true;
		GameManager.Instance.poisonerAvailable = poisonerToggle.isOn = false;
		GameManager.Instance.spyAvailable = spyToggle.isOn = false;
		GameManager.Instance.scarletWomanAvailable = scarletWomanToggle.isOn = false;
		GameManager.Instance.baronAvailable = baronToggle.isOn = false;
		GameManager.Instance.butlerAvailable = butlerToggle.isOn = false;
		GameManager.Instance.recluseAvailable = recluseToggle.isOn = false;
		GameManager.Instance.drunkAvailable = drunkToggle.isOn = false;
		GameManager.Instance.saintAvailable = saintToggle.isOn = false;
		GameManager.Instance.washerwomanAvailable = washerwomanToggle.isOn = false;
		GameManager.Instance.librarianAvailable = librarianToggle.isOn = false;
		GameManager.Instance.investigatorAvailable = investigatorToggle.isOn = false;
		GameManager.Instance.chefAvailable = chefToggle.isOn = false;
		GameManager.Instance.empathAvailable = empathToggle.isOn = false;
		GameManager.Instance.fortuneTellerAvailable = fortuneTellerToggle.isOn = false;
		GameManager.Instance.undertakerAvailable = undertakerToggle.isOn = false;
		GameManager.Instance.monkAvailable = monkToggle.isOn = false;
		GameManager.Instance.ravenkeeperAvailable = ravenkeeperToggle.isOn = false;
		GameManager.Instance.virginAvailable = virginToggle.isOn = false;
		GameManager.Instance.slayerAvailable = slayerToggle.isOn = false;
		GameManager.Instance.soldierAvailable = soldierToggle.isOn = false;
		GameManager.Instance.mayorAvailable = mayorToggle.isOn = false;

		SelectAllHit = false;
	}

	public void DoneSelecting()
	{
		print("RUNNING");
		//Calls a function to populate a list with true false values parallel to the CharacterRoles list in Gamemanager
		GameManager.Instance.UpdateAvailableRolesList();

		//Because CharacterRoles and AvailableRoles are parallel, we can say that if available roles [i] is true, we add character roles [i] to this scripts usable roles.
		//for example if available role[1] is the impAvailable and is true, then add imp to the availableRoles here.
		for(int i = 0; i < GameManager.Instance.characterRoles.Count; i++)
		{
			if (GameManager.Instance.availableRoles[i] == true)
			{
				print("DID ADD: " + GameManager.Instance.characterRoles[i].characterName);
				AvailableRoles.Add(GameManager.Instance.characterRoles[i]);
			}
			else
			{
				print("DID NOT ADD ROLE: " + GameManager.Instance.characterRoles[i].characterName);
			}
		}

		GameManager.Instance.characterRolesInCurrentGame = AvailableRoles;
		// Repeat as needed for other roles or use the ordered list from CharacterLibrary if you'd like to loop
	}
}
