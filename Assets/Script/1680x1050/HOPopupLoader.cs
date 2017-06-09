using UnityEngine;
using UnityEngine.SceneManagement;

public class HOPopupLoader : NNSingleton<HOPopupLoader> {

    string activePopupSceneName;
    public GameObject BackBoard;
    public void OnButtonPopup(string sceneName)
    {
        BackBoard.SetActive(true);
        activePopupSceneName = sceneName;
        SceneManager.LoadScene(activePopupSceneName, LoadSceneMode.Additive);
    }

    public void OnButtonClose()
    {
        BackBoard.SetActive(false);
        SceneManager.UnloadSceneAsync(activePopupSceneName);
    }
}
