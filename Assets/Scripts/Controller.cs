using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SerializationModel;

public class Controller : MonoBehaviour {

    [SerializeField]
    Model GameModel;

    [SerializeField]
    BattleView BattleV;

    void Start()
    {
        SwipeView.DidSwipe += Swipe;
        BattleView.OptionClicked += OnPlayerSelectOption;
        BattleView.OptionClicked += GetNPCResponse;

        BattleView.TypingDelayDone += ShowNPCResponse;
        Model.OnBattleFinish += BattleOver;
    }

    public void ChangeToView(IView nextView)
    {

    }

    #region SwipeScreen

    void Swipe(float amount)
    {

    }


    #endregion
    #region BattleScreen

    public List<ConversationOption> GetPlayerOptions()
    {
      return GameModel.GetPlayerOptions();
    }
    
    void OnPlayerSelectOption(int optionNumber)
    {
        BattleV.SetPlayerDialog(GameModel.GetRandomPlayerText(optionNumber));

        //select response from NPC and show
    }

    //Starts wait for NPC response
    void GetNPCResponse(int optionNumber)
    {
        BattleV.StartCoroutine(BattleV.NPCIstyping(optionNumber));
    }

    //Wait is over! Show the response.
    void ShowNPCResponse(int optionNumber) {
        BattleV.SetDateDialog(GameModel.GetNPCResponse(optionNumber));
        BattleV.SetPlayerOptions(GetPlayerOptions());

    }

    public void BattleOver(string endMessage)
    {
      BattleV.OnBattleEnd(endMessage);
    }
    #endregion
}
