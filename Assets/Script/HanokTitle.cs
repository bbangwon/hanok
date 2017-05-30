using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HanokTitle : MonoBehaviour
{

    public RectTransform backgroundImage;
    public RectTransform title;
    public RectTransform touchTitle;
    public RectTransform text1;
    public RectTransform text2;

    bool touchable = false;


    private void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerTap += FingerTap;
    }

    private void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerTap -= FingerTap;
    }

    // Use this for initialization
    void Start()
    {
        Initialize();
        LeanTween.color(backgroundImage, Color.white, 2f).setOnComplete(() =>
        {
            LeanTween.value(0f, 1f, 2f).setOnUpdate((v) =>
            {
                title.GetComponent<Image>().fillAmount = v;
            }).setOnComplete(() =>
            {
                touchable = true;
                LeanTween.alpha(touchTitle, 1.0f, 1.0f).setEaseOutQuad().setLoopPingPong();
            });

            LeanTween.scale(text1, Vector3.one, 0.5f).setDelay(1.0f);
            LeanTween.alpha(text1, 1.0f, 1.0f).setDelay(1.0f);

            LeanTween.scale(text2, Vector3.one, 0.5f).setDelay(1.5f);
            LeanTween.alpha(text2, 1.0f, 1.0f).setDelay(1.5f);
        });
    }

    void Initialize()
    {
        LeanTween.color(backgroundImage, Color.black, 0f);
        title.GetComponent<Image>().fillAmount = 0f;
        LeanTween.alpha(touchTitle, 0f, 0f);

        LeanTween.scale(text1, new Vector3(1.2f,1.2f,1.0f), 0f);
        LeanTween.alpha(text1, 0f, 0f);

        LeanTween.scale(text2, new Vector3(1.2f, 1.2f, 1.0f), 0f);
        LeanTween.alpha(text2, 0f, 0f);
    }
        

    void FingerTap(Lean.Touch.LeanFinger finger)
    {
        if(touchable)
        {
            SceneManager.LoadScene("touchScene");
        }
        
    }
}

