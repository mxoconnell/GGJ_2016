using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    /// <summary>
    /// Events and nonsense.
    /// </summary>

    public SwipeView SwipeV;
    public Animator SwipeA;

    public IView CurrentView;

    public void ChangeToView(IView nextView)
    {

    }
    //Event boilerplate
    //On Event, set animator parameters

    void Start()
    {
        SwipeView.DidSwipe += Swipe;
    }

    void Swipe(float amount)
    {
        SwipeA.SetFloat("Swipe", amount);
    }

    /// <summary>
    /// Getters
    /// </summary>

    public void GetCalendarInfo() { }
    public void GetSwipeInfo() { }
    public void GetBattleInfo() { }
}
