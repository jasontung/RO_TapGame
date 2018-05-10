using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeButtonBehavior : MonoBehaviour
{
    private SceneController sceneController;
    public string enableScene = "GameScene";
    public Button homeButton;
    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        sceneController.AfterSceneLoad += OnAfterSceneLoad;
    }

    private void OnAfterSceneLoad()
    {
        homeButton.interactable = SceneManager.GetActiveScene().name == enableScene;
    }

    private void OnDestroy()
    {
        sceneController.AfterSceneLoad -= OnAfterSceneLoad;
    }
}
