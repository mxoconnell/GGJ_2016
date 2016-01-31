using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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

    // Use this for initialization
    void Start() {
        DateDialogBox.gameObject.SetActive(false);
        PlayerDialogBox.gameObject.SetActive(false);
    }

    public static System.Action<int> OptionClicked;

    //Hooked up in the inspector
    public void Option0Clicked(int boxNumber)
    {
        OptionClicked(boxNumber);
    }

    public void SetPlayerDialog()
    {
        PlayerDialogBox.gameObject.SetActive(true);
    }

    public void SetDateDialog(string bodyText)
    {
        DateDialog.text = bodyText;
    }

    public void SetPlayerOptions(string[] options)
    {
        for(int i = 0; i< options.Length; ++i)
        {
            PlayerDialogOptions[i].text = options[i];
        }
    }
}
