using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    private void Awake()
    {
        Screen.SetResolution(1680, 1050, true);
#if !UNITY_EDITOR
        Cursor.visible = false;
#endif
    }

    // Use this for initialization
    void Start () {
        DG.Tweening.DOVirtual.DelayedCall(5f, () => {
            Lean.Touch.LeanTouch.OnFingerTap += (f) =>
            {
                Lean.Touch.LeanTouch.OnFingerTap = null;
                SceneManager.LoadScene("main");
            };
        });
	}
	

}
