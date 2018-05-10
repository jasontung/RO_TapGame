using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public event Action BeforeSceneUnload;
    public event Action AfterSceneLoad;

    public UIFader uiFader;
    public float fadeDuration = 0.5f;
    public string startingSceneName;

    private IEnumerator Start()
    {
        yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName));
        StartCoroutine(uiFader.Fade(0f, 0f, false));
    }


    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeAndSwitchScenes(sceneName));
    }


    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        yield return StartCoroutine(uiFader.Fade(1f, fadeDuration, true));
        if (BeforeSceneUnload != null)
            BeforeSceneUnload();
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
        yield return StartCoroutine(uiFader.Fade(0f, fadeDuration, false));
    }


    private IEnumerator LoadSceneAndSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newlyLoadedScene);
        if (AfterSceneLoad != null)
            AfterSceneLoad();
    }
}
