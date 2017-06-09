using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HOTweenFillAmount : MonoBehaviour {

    public float from = 0f;
    public float to = 1f;
    public float duration = 1f;
    public float delay = 0f;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().fillAmount = from;
        DOVirtual.Float(from, to, duration, (_) => GetComponent<Image>().fillAmount = _).SetDelay(delay);
	}
}
