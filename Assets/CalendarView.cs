using UnityEngine;
using System.Collections;
using System;

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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
