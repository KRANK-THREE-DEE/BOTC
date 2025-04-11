using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public GameObject notEnough;
    public void Scene2()
    {
        SceneManager.LoadScene("EnterNames");
    }

	public void Scene3()
	{
		if (GameManager.playerOrder.Count < GameManager.playerNumber)
		{
			notEnough.SetActive(true);
			Debug.Log("Not enough players.");
		}
		else
		{
			SceneManager.LoadScene("SelectRoles");
		}
	}

	public void Scene4()
	{
		SceneManager.LoadScene("Night1");
	}
}

