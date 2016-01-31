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

    [SerializeField]
    GameObject FinishDialogBox;

    [SerializeField]
    Text FinishDialog;

    // Use this for initialization
    void Start() {

      BattleStart();
    }

    void BattleStart()
    {
        //initialize      
       DateDialogBox.gameObject.SetActive(false);
       PlayerDialogBox.gameObject.SetActive(false);
       SetPlayerOptions(GameController.GetPlayerOptions());
    }


    public static System.Action<int> OptionClicked;
    public static System.Action<int> TypingDelayDone;

    //Hooked up in the inspector
    public void Option0Clicked(int boxNumber)
    {
        OptionClicked(boxNumber);
    }

    public IEnumerator NPCIstyping(int selectionNumber)
    {
        SetDateDialog("...");
        //Todo: make public/adjustable variable
        float typingDelay = UnityEngine.Random.Range(1.0f, 3.0f);

        yield return new WaitForSeconds(typingDelay);
        TypingDelayDone(selectionNumber);
    }

    public void SetPlayerDialog(string newText)
    {
        PlayerDialogBox.gameObject.SetActive(true);
        PlayerDialog.text = newText;
    }

    public void SetDateDialog(string bodyText)
    {
        DateDialogBox.gameObject.SetActive(true);
        DateDialog.text = bodyText;
    }

    public void SetPlayerOptions(List<ConversationOption> options)
    {
        for(int i = 0; i< options.Count; ++i)
        {
            PlayerDialogOptions[i].text = options[i].Name.ToString();
        }
    }

    void PlayerOptionVisibility(bool isVisible)
    {
        foreach(Text UIText in PlayerDialogOptions)
        {
            UIText.gameObject.SetActive(isVisible);
        }
    }

    public void OnBattleEnd(string finishText)
    {
        FinishDialog.text = finishText;
        PlayerOptionVisibility(false);
        FinishDialogBox.SetActive(true);
    }

    public void OnBattlePanelClosed()
    {
        PlayerOptionVisibility(true);
        //initialize
    }
}
