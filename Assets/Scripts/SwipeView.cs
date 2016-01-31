using UnityEngine;
using System.Collections;
using System;

//Buttons have OnClick methods tied via the editor to public methods

public class SwipeView : MonoBehaviour, IView  {
    public GameObject topCard;
    public GameObject bottomCard;

    Vector3 topCardOriginalPosition;
    bool canSwipe = true; //false when we are swiping
    float dx = 3;
    float dy = 2;


    void Start()
    {
        topCardOriginalPosition = topCard.transform.position;
    }
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

    int Selector = 0;

    [SerializeField]
    float SliderThreshold;


    public static System.Action<float> DidSwipe;

    // Update is called once per frame
    void Update()
    {
        if (!canSwipe)
        {
            var cardPosition = topCard.transform.position;
            cardPosition.x += dx;
            cardPosition.y += dy;
            topCard.transform.position = cardPosition;
            //fade out also

            //Card has left view. Allow user to swipe again. Move the bottom card to where the top was and bring it to the front. 
            if(cardPosition.x > 100 || cardPosition.x < -100)//TODO remove magic and compare to "topCardOriginalPosition"
            {
                canSwipe = true;
                dx = Math.Abs(dx);
                topCard.transform.position = bottomCard.transform.position;
                bottomCard.transform.position = topCardOriginalPosition;
                bottomCard.transform.SetAsLastSibling();

                //Now the top card and bottom card switch roles.
                var placeholder = topCard;
                topCard = bottomCard;
                bottomCard = topCard;

            }
        }
    }
 


    public void swipeCompleted(bool isRight)
    {
        if (canSwipe)
        {
            if (isRight)
                dx *= -1;

            Debug.Log("Swiped!");

            dy = UnityEngine.Random.Range(-dy, dy);
            Debug.Log(dy + ":dy");
            canSwipe = false;
            

        }
    }



    /*if (Input.GetMouseButtonUp(0) && CheckSliderBounds())
 {
     //Call controller event (SliderValue<-1 for left, SliderValue>1 for right)
     DidSwipe(LastSliderValue);

     if (LastSliderValue > 0)
     {
         Animators[0].SetTrigger("SwipeLeft");
     }
     if (LastSliderValue < 0)
     {
         Animators[0].SetTrigger("SwipeRight");
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
 else return false;*/

}
