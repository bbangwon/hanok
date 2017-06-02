using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class DirectorTouch : NNSingleton<DirectorTouch> {

    public RectTransform backgroundImage;
    public RectTransform house;
    public RectTransform sabuntuck;
    public RectTransform[] circles;    
    
    public RectTransform TopText;

    public GameObject BackBoard;

    float houseY;
    float sabunX;
    string activeSceneName;

    // Use this for initialization
    void Start () {
        Initialize();
        LeanTween.color(backgroundImage, Color.white, 2f).setOnComplete(() =>
        {
            LeanTween.moveY(house, houseY, 2f);//.setEaseInExpo();
            LeanTween.alpha(house, 1f, 2f);

            /*
            LeanTween.moveX(sabuntuck, sabunX, 2f).setEaseOutExpo().setDelay(1f);
            */
            LeanTween.alpha(sabuntuck, 1f, 1f).setDelay(3.5f);
            

            float delay = 2.0f;
             foreach (RectTransform c in circles)
             {
                 LeanTween.scale(c, Vector3.one, 1.2f).setEaseOutExpo().setDelay(delay).setOnComplete(() => {
                     if (c.GetComponent<Animator>())
                         c.GetComponent<Animator>().enabled = true;
                 });
                 delay += 0.2f;
             }

             LeanTween.alpha(TopText, 1f, 1f).setDelay(2f).setEaseOutQuad();
        });        
    }

    void Initialize()
    {
        houseY = house.position.y;
        sabunX = sabuntuck.position.x;

        LeanTween.color(backgroundImage, Color.black, 0f);
        LeanTween.moveY(house, houseY - 30f, 0f);
        LeanTween.alpha(house, 0f, 0f);

  
//        LeanTween.moveX(sabuntuck, -435f, 0f);
        LeanTween.alpha(sabuntuck, 0f, 0f);
  

        foreach (RectTransform c in circles)
        {
            if(c.GetComponent<Animator>())
                c.GetComponent<Animator>().enabled = false;
            LeanTween.scale(c, Vector3.zero, 0f);

        }

        LeanTween.alpha(TopText, 0f, 0f);
        
    }

    public void OnButtonPopup(string sceneName)
    {
        BackBoard.SetActive(true);
        activeSceneName = sceneName;
        SceneManager.LoadScene(activeSceneName, LoadSceneMode.Additive);
    }

    public void OnButtonClose()
    {
        BackBoard.SetActive(false);
        SceneManager.UnloadSceneAsync(activeSceneName);
    }

}
