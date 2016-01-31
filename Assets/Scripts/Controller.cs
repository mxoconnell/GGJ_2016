using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    
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

    void OnBattleStart()
    {
        
    }
    
    void OnPlayerSelectOption(int optionNumber)
    {
        //do something with the game logic
    }
}
