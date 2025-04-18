using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player
{
	public string playerName;

	public string characterName;
	public CharacterLibrary.Alignment alignment;
	public bool isPoisoned;
	public bool isMaster;

	public Player()
	{
		playerName = string.Empty;
		characterName = string.Empty;
		alignment = CharacterLibrary.Alignment.Townsfolk;
		isPoisoned = false;
		isMaster = false;
	}

	public Player(string name, string characterName = "Unknown", CharacterLibrary.Alignment alignment = CharacterLibrary.Alignment.Townsfolk)
	{
		this.playerName = name;
		this.characterName = characterName;
		this.alignment = alignment;
	}

}


