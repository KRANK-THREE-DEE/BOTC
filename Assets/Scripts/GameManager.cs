using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterLibrary;

public class GameManager : Singleton<GameManager>
{
	public int playerNumber;
	public List<Player> playerOrder = new List<Player>();
	public List<string> playerTotalNames = new List<string>();

	public bool impAvailable;
	public bool poisonerAvailable;
	public bool spyAvailable;
	public bool scarletWomanAvailable;
	public bool baronAvailable;
	public bool butlerAvailable;
	public bool recluseAvailable;
	public bool drunkAvailable;
	public bool saintAvailable;
	public bool washerwomanAvailable;
	public bool librarianAvailable;
	public bool investigatorAvailable;
	public bool chefAvailable;
	public bool empathAvailable;
	public bool fortuneTellerAvailable;
	public bool undertakerAvailable;
	public bool monkAvailable;
	public bool ravenkeeperAvailable;
	public bool virginAvailable;
	public bool slayerAvailable;
	public bool soldierAvailable;
	public bool mayorAvailable;
	public List<bool> availableRoles = new List<bool>();
	public List<CharacterRole> characterRoles = new List<CharacterRole>();
	public List<CharacterRole> characterRolesInCurrentGame = new List<CharacterRole>();
	private void Start()
	{
		impAvailable = true;
		GetAllRolesInOrder();
	}
	public void GetAllRolesInOrder()
	{
		characterRoles.Add(new CharacterRole("Imp", CharacterLibrary.Alignment.Demon));
		characterRoles.Add(new CharacterRole("Poisoner", CharacterLibrary.Alignment.Minion));
		characterRoles.Add(new CharacterRole("Spy", CharacterLibrary.Alignment.Minion));
		characterRoles.Add(new CharacterRole("Scarlet Woman", CharacterLibrary.Alignment.Minion));
		characterRoles.Add(new CharacterRole("Baron", CharacterLibrary.Alignment.Minion));
		characterRoles.Add(new CharacterRole("Butler", CharacterLibrary.Alignment.Outsider));
		characterRoles.Add(new CharacterRole("Recluse", CharacterLibrary.Alignment.Outsider));
		characterRoles.Add(new CharacterRole("Drunk", CharacterLibrary.Alignment.Outsider));
		characterRoles.Add(new CharacterRole("Saint", CharacterLibrary.Alignment.Outsider));
		characterRoles.Add(new CharacterRole("Washerwoman", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Librarian", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Investigator", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Chef", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Empath", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Fortune Teller", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Undertaker", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Monk", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Ravenkeeper", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Virgin", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Slayer", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Soldier", CharacterLibrary.Alignment.Townsfolk));
		characterRoles.Add(new CharacterRole("Mayor", CharacterLibrary.Alignment.Townsfolk));
		for (int i = 0; i < characterRoles.Count; i++)
		{
			print("ADDED THE ROLE: " + characterRoles[i].characterName + " TO THE FUCKING ROLE LIST");
		}
	}


	public void UpdateAvailableRolesList()
	{

		GameManager.Instance.availableRoles.Clear();
		GameManager.Instance.characterRolesInCurrentGame.Clear();

		GameManager.Instance.availableRoles.Add(GameManager.Instance.impAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.poisonerAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.spyAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.scarletWomanAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.baronAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.butlerAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.recluseAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.drunkAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.saintAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.washerwomanAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.librarianAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.investigatorAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.chefAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.empathAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.fortuneTellerAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.undertakerAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.monkAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.ravenkeeperAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.virginAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.slayerAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.soldierAvailable);
		GameManager.Instance.availableRoles.Add(GameManager.Instance.mayorAvailable);

		for(int i = 0; i < availableRoles.Count; i++)
		{
			if (availableRoles[i] == true)
			{
				characterRolesInCurrentGame.Add(characterRoles[i]);
			}
		}
	}

}
