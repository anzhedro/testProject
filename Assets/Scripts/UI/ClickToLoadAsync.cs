using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToLoadAsync : MonoBehaviour
{
    public Slider loadingBar;
    public GameObject loadingImage;

    private AsyncOperation async;

    public void Exit()
    {
        Application.Quit();
    }
    public void Settings()
    {

    }
    public void ClickAsync(int level)
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(level));
    }

    IEnumerator LoadLevelWithBar(int level)
    {
        async = SceneManager.LoadSceneAsync(level);
        //async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
