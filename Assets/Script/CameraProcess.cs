using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraProcess : MonoBehaviour {


    public GameObject HanOk;
    public Vector3 MovieToCameraPos;
    public Vector3 TouchToCameraPos;

    public GameObject Infomation;
    public GameObject movieShowButton;
    public Camera popupCamera;

    public void MovieReplay()
    {
        HanOk.gameObject.SetActive(false);
        CameraToMovie(1f);
        LeanTween.delayedCall(1f, () => {
            HanOk.gameObject.SetActive(true);
        });
    }

    public void Close()
    {
        DirectorTouch.Instance.OnButtonClose();
    }

    public void CameraToMovie(float duration)
    {
        movieShowButton.SetActive(false);
        LeanTween.move(popupCamera.gameObject, MovieToCameraPos, duration);
    }

    public void CameraToTouch(float duration)
    {
        movieShowButton.SetActive(false);
        LeanTween.move(popupCamera.gameObject, TouchToCameraPos, duration).setOnComplete(()=> {
            movieShowButton.SetActive(true);
        });
    }

    public void InfomationShow()
    {
        Lean.Touch.LeanTouch.OnFingerDown += FingerDown;
        Infomation.SetActive(true);
        
    }

    public void InfomationHide()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= FingerDown;
        Infomation.SetActive(false);
    }

    void FingerDown(Lean.Touch.LeanFinger f)
    {
        InfomationHide();
    }
}
