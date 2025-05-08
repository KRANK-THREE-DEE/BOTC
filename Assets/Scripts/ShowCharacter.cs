using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public TMP_Text text;

    public GameObject notif;

	private void Start()
	{
        notif = GameObject.Find("Notification");
	}
	public void Show()
    {
		RectTransform rt = notif.GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector2(-20f, -40f);
        Debug.Log("woah there's a method here and it works");
        //this is on the buttons in ViewRoles scene
        //will show what role they are
    }

    public void Hide()
    {
		RectTransform rt = notif.GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector2(900f, 900f);
	}
}
