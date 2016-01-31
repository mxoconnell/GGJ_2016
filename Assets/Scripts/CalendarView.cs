using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//Buttons have OnClick methods tied via the editor to public methods

public class CalendarView : MonoBehaviour
{
    [SerializeField]
    Image[] CalendarBookedGraphics;

    // Use this for initialization
    void Start() {

    }

    void SetCalendarGraphics()
    {
        for(int i = 0; i < CalendarBookedGraphics.Length; ++i)
        {

        }
    }
}
