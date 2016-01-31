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
	GameObject DateDialogBoxPrefab;

	[SerializeField]
	GameObject PlayerDialogBoxPrefab;

	[SerializeField]
	RectTransform MessageWindow;

    [SerializeField]
    Text[] PlayerDialogOptions;

    [SerializeField]
    Controller GameController;

    [SerializeField]
    GameObject FinishDialogBox;

    [SerializeField]
    Text FinishDialog;

	private float MessageBoxTranslation = 0;

    // Use this for initialization
    void Start() {

      BattleStart();
    }

    void BattleStart()
    {
        //initialize      
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

	private void SetDialog(GameObject prefab, string text)
	{
		// Add the actual dialog object and set its content
		GameObject newDialog = Instantiate<GameObject>(prefab);
		newDialog.transform.SetParent(MessageWindow.transform, false);
		newDialog.GetComponentInChildren<Text>().text = text;

		// Move the dialog to the bottom of the screen
		var newDialogTransform = newDialog.GetComponent<RectTransform>();
		newDialogTransform.anchoredPosition += Vector2.down * MessageBoxTranslation;
		MessageBoxTranslation += newDialogTransform.rect.height;

		// Increase the message window size and position
		MessageWindow.sizeDelta = new Vector2(MessageWindow.sizeDelta.x, MessageBoxTranslation);
		MessageWindow.localPosition = new Vector3(0, MessageBoxTranslation, 0);
	}

    public void SetPlayerDialog(string newText)
    {
		SetDialog(PlayerDialogBoxPrefab, newText);
    }

    public void SetDateDialog(string bodyText)
    {
		SetDialog(DateDialogBoxPrefab, bodyText);
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
