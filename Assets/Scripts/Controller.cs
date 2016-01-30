using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public SwipeView SwipeV;
    public Animator SwipeA;

    public IView CurrentView;

    public void ChangeToView(IView nextView)
    {

    }

    public void GetCalendarInfo() { }
    public void GetSwipeInfo() { }
    public void GetBattleInfo() { }

    //Event boilerplate
    //On Event, set animator parameters

    void Start()
    {
        SwipeView.DidSwipe += SetControllerParam;
    }

    void SetControllerParam(float amount)
    {
        SwipeA.SetFloat("Swipe", amount);
    }
}
