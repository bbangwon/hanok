using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;

public class HOPopupLoader : NNSingleton<HOPopupLoader> {

    string activePopupSceneName;
    public GameObject BackBoard;

    System.IDisposable timer;
    Subject<bool> events = new Subject<bool>();
    private void Start()
    {
        Observable.Timer(System.TimeSpan.FromMinutes(3))    //3분후 타이틀로 이동
            .TakeUntil(events)
            .RepeatUntilDestroy(this)
            .Subscribe(_ => BackTitleScene())
            .AddTo(this);
    }

    public void OnButtonPopup(string sceneName)
    {
        ResetTimer();
        BackBoard.SetActive(true);
        activePopupSceneName = sceneName;
        SceneManager.LoadScene(activePopupSceneName, LoadSceneMode.Additive);
    }

    public void OnButtonClose()
    {
        ResetTimer();
        BackBoard.SetActive(false);
        SceneManager.UnloadSceneAsync(activePopupSceneName);        
    }

    public void ResetTimer()
    {
        //타이머 리셋
        events.OnNext(true);
    }

    public void BackTitleScene()
    {
        SceneManager.LoadScene("title");
    }
}
