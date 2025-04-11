using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLibrary : MonoBehaviour
{
	public enum Alignment
	{
		Townsfolk,
		Outsider,
		Minion,
		Demon
	}

	public class CharacterRole
	{
		public string characterName;
		public Alignment alignment;

		public CharacterRole(string name, Alignment alignment)
		{
			characterName = name;
			this.alignment = alignment;
		}
	}


	public static List<CharacterRole> townsfolkRoles = new List<CharacterRole>
	{
		new CharacterRole("Washerwoman", Alignment.Townsfolk),
		new CharacterRole("Librarian", Alignment.Townsfolk),
		new CharacterRole("Investigator", Alignment.Townsfolk),
		new CharacterRole("Chef", Alignment.Townsfolk),
		new CharacterRole("Empath", Alignment.Townsfolk),
		new CharacterRole("Fortune Teller", Alignment.Townsfolk),
		new CharacterRole("Undertaker", Alignment.Townsfolk),
		new CharacterRole("Monk", Alignment.Townsfolk),
		new CharacterRole("Ravenkeeper", Alignment.Townsfolk),
		new CharacterRole("Virgin", Alignment.Townsfolk),
		new CharacterRole("Slayer", Alignment.Townsfolk),
		new CharacterRole("Soldier", Alignment.Townsfolk),
		new CharacterRole("Mayor", Alignment.Townsfolk),
	};

	public static List<CharacterRole> outsiderRoles = new List<CharacterRole>
	{
		new CharacterRole("Butler", Alignment.Outsider),
		new CharacterRole("Drunk", Alignment.Outsider),
		new CharacterRole("Recluse", Alignment.Outsider),
		new CharacterRole("Saint", Alignment.Outsider),
	};

	public static List<CharacterRole> minionRoles = new List<CharacterRole>
	{
		new CharacterRole("Poisoner", Alignment.Minion),
		new CharacterRole("Spy", Alignment.Minion),
		new CharacterRole("Scarlet Woman", Alignment.Minion),
		new CharacterRole("Baron", Alignment.Minion),
	};

	public static List<CharacterRole> demonRoles = new List<CharacterRole>
	{
		new CharacterRole("Imp", Alignment.Demon),
	};
}
