using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Hanok : MonoBehaviour {

    bool touchable = false;
    public Lean.Touch.LeanPitchYawSmooth LeanTouchRotation;
    public Animation defaultAnimation;

    private void Start()
    {
        this.UpdateAsObservable().Select(_ => defaultAnimation.isPlaying).DistinctUntilChanged().Where(_ => !_).Subscribe(_ => OnDefaultAnimationEnd());        
    }

    // Use this for initialization
    private void OnEnable()
    {
        defaultAnimation.Play();        
    }

    private void OnDisable()
    {
        LeanTween.cancel(gameObject);
        LeanTouchRotation.enabled = false;
        transform.rotation = Quaternion.identity;
        LeanTouchRotation.Yaw = 0f;
        LeanTouchRotation.Pitch = 0f;
    }

    void OnDefaultAnimationEnd()
    {
        LeanTween.rotateY(gameObject, 180f, 3f).setOnComplete(() => {
            LeanTween.rotateY(gameObject, 360f, 3f).setOnComplete(() => {
                touchable = true;
                LeanTouchRotation.enabled = true;
            });
        });
    }
}
