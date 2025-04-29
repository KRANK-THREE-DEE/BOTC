using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ViewRoles : MonoBehaviour
{
    //on Enter Button in ViewRoles scene, will run onClick
    //take input from input field and match to player name in game Manager
    //if match, show player role name + role information and bring up continue button
    //on continue button, close and clear role info text
    //if no match, show text saying retype
    //increase int if close button hit 
    //if int = amount of players, Start Night button is interactable
    //make lower?

    public TMP_Text roleText;
    public TMP_InputField inputField;
    public Button closeButton;

    public int buttonActivateCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
