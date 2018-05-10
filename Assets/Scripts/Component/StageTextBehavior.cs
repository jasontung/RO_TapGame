using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageTextBehavior : MonoBehaviour {

    private SceneController sceneController;
    public string enableScene = "GameScene";
    public Text stageText;
    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        sceneController.AfterSceneLoad += OnAfterSceneLoad;
    }

    private void OnAfterSceneLoad()
    {
        if (SceneManager.GetActiveScene().name == enableScene)
            stageText.text = "Stage 1";
        else
            stageText.text = string.Empty;
    }

    private void OnDestroy()
    {
        sceneController.AfterSceneLoad -= OnAfterSceneLoad;
    }
}
