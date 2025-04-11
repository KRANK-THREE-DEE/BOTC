using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NightOne : MonoBehaviour
{
    public TMP_Text gameText;

	void Start()
	{
		float duration = 5f;
		StartCoroutine(TimeBetweenRoles(duration));
	}

	IEnumerator TimeBetweenRoles(float duration)
	{
		gameText.text = "Take a sec, go to sleep.";
		Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
		yield return new WaitForSeconds(duration);
		Debug.Log($"Ended at {Time.time}");
		//whatever thing has minions wake up here. probably audio cue.
		if (GameManager.playerNumber >= 7)
		{
			StartCoroutine(Minions(5f));
		}
		else
		{
			Poisoner();
		}
	}


	IEnumerator Minions(float delay) //time for minions to see each other (only if 7 or more players)
	{
		gameText.text = "minions do ur thing (big game)";
		Debug.Log($"Started at {Time.time}");
		yield return new WaitForSeconds(5);
		Debug.Log($"Ended at {Time.time}");
		//whatever thing has minions sleep here.
		StartCoroutine(Demon(15f));
	}

	IEnumerator Demon(float delay) //time for demon to see who minions are and get bluffs (only if 7 or more players)
	{
		gameText.text = "demon do ur thing (big game)";
		//whatever thing has minions stick thumb out (or jackbox jus showing names on phone)
		Debug.Log($"Started at {Time.time}");
		yield return new WaitForSeconds(5);
		Debug.Log($"Ended at {Time.time}");
		gameText.text = "Timer done.";
		//minions put thumbs down
		//demon sees 3 not in play roles to bluff as
		//whatever thing has demons sleep here.
		Poisoner();
	}

	public void Poisoner()
	{
		gameText.text = "poisoner do ur thing";
		//display players on screen (scroll view same as roles earlier)
		//poisoner chooses one to poison
		//make that person poisoned
		//if poisoner role not in game waits random time between 8-15 seconds
		//poisoner sleeps
	}

}
