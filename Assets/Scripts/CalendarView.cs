﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//Buttons have OnClick methods tied via the editor to public methods

public class CalendarView : MonoBehaviour, IView
{
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
    Image[] CalendarBookedGraphics;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}