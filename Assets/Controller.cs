using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public IView CurrentView;

    public void ChangeToView(IView nextView)
    {

    }

    public void GetCalendarInfo() { }
    public void GetSwipeInfo() { }
    public void GetBattleInfo() { }

    //Event boilerplate
    //On Event, set animator parameters
}
