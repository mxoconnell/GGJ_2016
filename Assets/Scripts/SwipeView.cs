using UnityEngine;
using System.Collections;
using System;

//Buttons have OnClick methods tied via the editor to public methods

public class SwipeView : MonoBehaviour, IView  {

    public void ChangeView(IView nextView)
    {
        throw new NotImplementedException();
    }

    public RectTransform GetRoot()
    {
        return Root;
    }

    [SerializeField]
    RectTransform Root;

    [SerializeField]
    Animator Controller;

    [SerializeField]
    RectTransform[] SwipeScreens;

    [SerializeField]
    RectTransform ForegroundSwipeScreen;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //assigned via inspector.
    public void Swipe(bool SwipeLeft)
    {
        //Call controller event (True for left, false for right)
        //Wait then Swap foreground for BG
    }
}
