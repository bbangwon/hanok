using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

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
