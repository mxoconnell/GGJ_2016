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
	float MessageSpacing = 10f;

    [SerializeField]
    Text[] PlayerDialogOptions;

    [SerializeField]
    Controller GameController;

    [SerializeField]
    GameObject FinishDialogBox;

    [SerializeField]
    Text FinishDialog;

    int LastBattleWon = 0;

    [SerializeField]
    GameObject[] FinishDialogBoxButtons;

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
        float typingDelay = UnityEngine.Random.Range(0.5f, 2.0f);

        yield return new WaitForSeconds(typingDelay);
        TypingDelayDone(selectionNumber);
    }

	private IEnumerator SetDialog(GameObject prefab, string text)
	{
		// Add the actual dialog object and set its content
		GameObject newDialog = Instantiate<GameObject>(prefab);
		newDialog.GetComponentInChildren<Text>().text = text;
		newDialog.transform.SetParent(MessageWindow.transform, false);

		// Need to delay a bit for the layout to update the rect transform to update
		yield return new WaitForSeconds(0.01f);

		// Move the dialog to the bottom of the screen
		var newDialogTransform = newDialog.GetComponent<RectTransform>();
		Debug.Log(newDialogTransform.rect.height);
		newDialogTransform.anchoredPosition += Vector2.down * (MessageBoxTranslation + newDialogTransform.rect.height/2);
		MessageBoxTranslation += newDialogTransform.rect.height + MessageSpacing;

		// Increase the message window size and position
		MessageWindow.sizeDelta = new Vector2(MessageWindow.sizeDelta.x, MessageBoxTranslation);
		MessageWindow.localPosition = new Vector3(0, MessageBoxTranslation, 0);
	}

    public void SetPlayerDialog(string newText)
    {
		StartCoroutine(SetDialog(PlayerDialogBoxPrefab, newText));
    }

    public void SetDateDialog(string bodyText)
    {
		StartCoroutine(SetDialog(DateDialogBoxPrefab, bodyText));
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

    public void OnBattleEnd(bool didWin)
    {
        PlayerOptionVisibility(false);
        FinishDialogBox.SetActive(true);

        if (didWin)
        {
            FinishDialog.text = "Grats! You won! Click to go to the calendar and schedule your date.";
            FinishDialogBoxButtons[0].SetActive(true);
        }
        else
        {
            FinishDialog.text = "And they were never heard from again.";
            FinishDialogBoxButtons[1].SetActive(true);
        }

        
    }

    public void OnBattlePanelClosed()
    {
        PlayerOptionVisibility(true);

        foreach(Transform child in MessageWindow.transform)
        {
            Destroy(child.gameObject);
        }
        FinishDialogBox.SetActive(false);
        FinishDialogBoxButtons[0].SetActive(false);
        FinishDialogBoxButtons[1].SetActive(false);
        //initialize
    }
}
