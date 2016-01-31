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

    float LastSliderValue = 0.0f;

    [SerializeField]
    RectTransform Root;

    [SerializeField]
    RectTransform[] SwipeScreens;

    [SerializeField]
    Animator[] Animators;

    [SerializeField]
    RectTransform ForegroundSwipeScreen;
    Animator ForegroundAnimator;

    int Selector = 0;

    [SerializeField]
    float SliderThreshold;

    // Use this for initialization
    void Start () {
        ForegroundSwipeScreen = SwipeScreens[Selector];
        ForegroundAnimator = Animators[Selector];
	}

    public static System.Action<float> DidSwipe;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && CheckSliderBounds())
        {
            Debug.Log("Let go");
            //Call controller event (SliderValue<-1 for left, SliderValue>1 for right)
            DidSwipe(LastSliderValue);

            if (LastSliderValue > 0)
            {
                ForegroundAnimator.SetTrigger("SwipeLeft");
            }
            if (LastSliderValue < 0)
            {
                ForegroundAnimator.SetTrigger("SwipeRight");
            }
            //Wait then Swap foreground for BG, 
            LastSliderValue = 0.0f;
        }
    }

    //assigned via inspector.
    public void Swipe(Vector2 SliderValue)
    {
        LastSliderValue = SliderValue.x;
    }

    bool CheckSliderBounds()
    {
        if (LastSliderValue > SliderThreshold || LastSliderValue < -SliderThreshold)
        {
            return true;
        }
        else return false;
    }
}
