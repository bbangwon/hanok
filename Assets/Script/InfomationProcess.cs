using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfomationProcess : MonoBehaviour {

    public GameObject Infomation;
    public GameObject movieShowButton;

    public void Show()
    {
        Lean.Touch.LeanTouch.OnFingerDown += FingerDown;
        Infomation.SetActive(true);
        movieShowButton.SetActive(true);
    }

    public void Hide()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= FingerDown;
        Infomation.SetActive(false);
    }

    void FingerDown(Lean.Touch.LeanFinger finger)
    {
        Hide();
    }
}
