using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    public int ScreenWidth;
    public int ScreenHeight;

    public Camera cam;

	// Use this for initialization
	void Start () {
        //float margin = Random.Range(0.0f, 0.3f);

        //LeanTween.value(0.5f, 0.2f, 3f).setOnUpdate((v) => { cam.rect = new Rect(v, v, 1.0f - v * 2.0f, 1.0f-v*2.0f); });


        //cam.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
