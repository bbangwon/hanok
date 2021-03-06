﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ModelControl : MonoBehaviour {

    bool touchable = false;
    public Lean.Touch.LeanPitchYawSmooth LeanTouchRotation;
    public Animation defaultAnimation;

    public CameraProcess cameraProcess;

    bool movieReplying = false;

    private void Start()
    {                
        cameraProcess.GetComponent<CameraProcess>().CameraToMovie(0f);
        this.UpdateAsObservable().Select(_ => defaultAnimation.isPlaying).DistinctUntilChanged().Where(_ => !_).Subscribe(_ => OnDefaultAnimationEnd());        
    }

    // Use this for initialization
    private void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerDown += FingerDown;
        defaultAnimation.Play();        
    }

    private void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= FingerDown;

        LeanTween.cancel(gameObject);
        LeanTouchRotation.enabled = false;
        transform.rotation = Quaternion.identity;
        LeanTouchRotation.Yaw = 0f;
        LeanTouchRotation.Pitch = 0f;
    }   

    void FingerDown(Lean.Touch.LeanFinger f)    //터치가 있으면 타이머를 리셋
    {
        HOPopupLoader.Instance.ResetTimer();
    }

    void OnDefaultAnimationEnd()
    {
        if (movieReplying)
            return;

        cameraProcess.GetComponent<CameraProcess>().CameraToTouch(5f);
        LeanTween.rotateY(gameObject, 180f, 3f).setOnComplete(() => {
            LeanTween.rotateY(gameObject, 360f, 3f).setOnComplete(() => {
                //카메라
                touchable = true;
                LeanTouchRotation.enabled = true;
                cameraProcess.InfomationShow();
            });
        });
    }    
}
