using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
	public AudioSource audioSource;
	//voice is ttsmp3.com: amy

	void Start()
	{
		audioSource.Play();
	}
}
