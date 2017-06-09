using UnityEngine;
using UnityEngine.UI;

public class BlinkButton : MonoBehaviour {

    public float delayStart;
    public float target = 0.0f;
    public float everyDelayTime = 1.2f;

    public float showHideTime = 0.6f;

    // Use this for initialization
    void Start () {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.delayedCall(delayStart, Blink);
    }


    void Blink()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1f, showHideTime).setOnComplete(() =>
        {
            LeanTween.alpha(gameObject.GetComponent<RectTransform>(), target, showHideTime).setOnComplete(() => {
                LeanTween.delayedCall(everyDelayTime, Blink);
            });
        });

    }


}
