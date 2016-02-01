using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//Buttons have OnClick methods tied via the editor to public methods

public class CalendarView : MonoBehaviour
{
    public GameObject popupMidGame;
    public GameObject popupEndGame;

    public GameObject SwipeScreen;
    public GameObject CalendarScreen;

    public Sprite dateOccupied;
    public GameObject[] days;
    bool[] daysFilled = { true, false, false, false, false, false, false };//true if that day is filled
    [SerializeField]
    Image[] CalendarBookedGraphics;
    bool canPick = true;

    // Use this for initialization
    void Start() {
        DisplayBookedDays();//initialize any pre-booked days
    }

    void DisplayBookedDays()
    {
        int numberOfDates = 0;
        for(int day = 0; day < daysFilled.Length; day++)
        {
            if (daysFilled[day])
            {
                numberOfDates++;
                //Debug.Log("day #" + day + " is booked!");
                //add a heart if we have a date on that day
                days[day].GetComponent<Image>().sprite = dateOccupied;
                days[day].GetComponent<Button>().interactable = false;


            }
        }

        //All dates filled
        if(numberOfDates == daysFilled.Length)
        {
            popupMidGame.SetActive(false);
            popupEndGame.SetActive(true);
        }
    }

    public void AddANewDate(int day)
    {
        if (canPick){
            canPick = false;
            daysFilled[day] = true;
            popupMidGame.SetActive(true);
            DisplayBookedDays();
        }
        
    }

    public void returnToGame(GameObject popup)
    {
        popup.SetActive(false);
        StartCoroutine(waitABitThenReturn());
        
    }

    IEnumerator waitABitThenReturn()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        print(Time.time);
        canPick = true;

        CalendarScreen.SetActive(false);
        SwipeScreen.SetActive(true);
    }

}
