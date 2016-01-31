using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using SerializationModel;

//Buttons have OnClick methods tied via the editor to public methods

public class BattleView : MonoBehaviour
{
    [SerializeField]
    RectTransform DateDialogBox;

    [SerializeField]
    Text DateDialog;

    [SerializeField]
    RectTransform PlayerDialogBox;

    [SerializeField]
    Text PlayerDialog;

    [SerializeField]
    Text[] PlayerDialogOptions;

    [SerializeField]
    Controller GameController;

    // Use this for initialization
    void Start() {
        DateDialogBox.gameObject.SetActive(false);
        PlayerDialogBox.gameObject.SetActive(false);
        BattleStart();
    }

    void BattleStart()
    {
        SetPlayerOptions(GameController.GetPlayerOptions());
    }


    public static System.Action<int> OptionClicked;

    //Hooked up in the inspector
    public void Option0Clicked(int boxNumber)
    {
        OptionClicked(boxNumber);
    }

    public void SetPlayerDialog(string newText)
    {
        PlayerDialogBox.gameObject.SetActive(true);
        PlayerDialog.text = newText;
    }

    public void SetDateDialog(string bodyText)
    {
        DateDialog.text = bodyText;
    }

    public void SetPlayerOptions(List<ConversationOption> options)
    {
        for(int i = 0; i< options.Count; ++i)
        {
            PlayerDialogOptions[i].text = options[i].Name.ToString();
        }
    }
}
