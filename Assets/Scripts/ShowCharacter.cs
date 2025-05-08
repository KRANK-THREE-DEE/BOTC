using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public TMP_Text notifText;

    public GameObject notif;

    public string buttonText;

    private void Start()
    {
        notif = GameObject.Find("Notification");
		Transform roleTextTransform = notif.transform.Find("RoleText");
		notifText = roleTextTransform.GetComponent<TMP_Text>();
        buttonText = GetComponentInChildren<TMP_Text>().text;

	}
	public void Show()
    {
		RectTransform rt = notif.GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector2(-20f, -40f);
        Debug.Log(buttonText); //works
		foreach (var player in GameManager.Instance.playerOrder)
        {
            if (player.playerName == buttonText)
            {
				notifText.text = player.characterName;
			}
        }
		//notifText.text = "plz"; 
        //this is on the buttons in ViewRoles scene
        //will show what role they are

    }

    public void Hide() //this is on the close button 
    {
		RectTransform rt = notif.GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector2(900f, 900f);
	}
}
