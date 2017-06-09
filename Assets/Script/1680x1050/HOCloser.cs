using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOCloser : MonoBehaviour {

    public void OnButtonClose()
    {
        HOPopupLoader.Instance.OnButtonClose();
    }
}
