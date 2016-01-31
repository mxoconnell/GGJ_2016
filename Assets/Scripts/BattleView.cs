using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

//Buttons have OnClick methods tied via the editor to public methods

public class BattleView : MonoBehaviour
{
    [SerializeField]
    RectTransform Date_DialogBox;

    [SerializeField]
    Text Date_Dialog;

    [SerializeField]
    RectTransform Player_DialogBox;

    [SerializeField]
    Text Player_Dialog;

    [SerializeField]
    SerializationModel.ConversationNode CurrentNode;

    // Use this for initialization
    void Start() {
        Date_DialogBox.gameObject.SetActive(false);
        Player_DialogBox.gameObject.SetActive(false);
    }

    //Hooked up in the inspector
    public void Option0Clicked()
    {
        SetNextNode();
    }
    public void Option1Clicked()
    {
        SetNextNode();
    }
    public void Option2Clicked()
    {
        SetNextNode();
    }
    public void Option3Clicked()
    {
        SetNextNode();
    }

    void SetNextNode()
    {
      
    }

    void SetPlayerDialog()
    {

    }

    void SetDateDialog()
    {

    }

    void SetPlayerOptions()
    {

    }
}
