using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SerializationModel;

public class Controller : MonoBehaviour {

    [SerializeField]
    Model GameModel;
    [SerializeField]
    BattleView BattleV;

    public void ChangeToView(IView nextView)
    {

    }

    void Start()
    {
        SwipeView.DidSwipe += Swipe;
        BattleView.OptionClicked += OnPlayerSelectOption;
    }

    void Swipe(float amount)
    {

    }

    /// <summary>
    /// Getters
    /// </summary>

    public void GetCalendarInfo() { }
    public void GetSwipeInfo() { }
    public void GetBattleInfo() { }

    public List<ConversationOption> GetPlayerOptions()
    {
      return GameModel.GetPlayerOptions();
    }
    
    void OnPlayerSelectOption(int optionNumber)
    {
        //do something with the game logic
        BattleV.SetPlayerDialog(GameModel.GetRandomPlayerText(optionNumber));
    }


}
