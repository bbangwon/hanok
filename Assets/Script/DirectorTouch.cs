using UnityEngine;
using UnityEngine.UI;

public class DirectorTouch : MonoBehaviour {

    public RectTransform backgroundImage;
    public RectTransform house;
    public RectTransform[] circles;

    public RectTransform BottomText;
    public RectTransform TopText;

    public GameObject popup;

    // Use this for initialization
    void Start () {

        Initialize();
        LeanTween.color(backgroundImage, Color.white, 2f).setOnComplete(() =>
        {
             LeanTween.moveY(house, 0f, 2f).setEaseInExpo();

             float delay = 2.0f;
             foreach (RectTransform c in circles)
             {
                 LeanTween.scale(c, Vector3.one, 0.5f).setDelay(delay);
                 delay += 0.2f;
             }

             LeanTween.alpha(BottomText, 1f, 1f).setDelay(2f);
             LeanTween.alpha(TopText, 1f, 1f).setDelay(2f).setEaseOutQuad().setLoopPingPong();
        });
    }


    void Initialize()
    {
        LeanTween.color(backgroundImage, Color.black, 0f);
        LeanTween.moveY(house, 850f, 0f);

        foreach (RectTransform c in circles)
        {
            LeanTween.scale(c, Vector3.zero, 0f);
        }

        LeanTween.alpha(BottomText, 0f, 0f);
        LeanTween.alpha(TopText, 0f, 0f);
    }

    public void OnButton1Click()
    {
        popup.SetActive(true);
    }

    public void OnButtonPopupClose()
    {
        popup.SetActive(false);
    }


}
