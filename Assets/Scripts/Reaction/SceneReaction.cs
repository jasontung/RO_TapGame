using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReaction : MonoBehaviour {

    public string sceneName;


    private SceneController sceneController;


    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
    }


    public void React()
    {
        sceneController.FadeAndLoadScene(sceneName);
    }
}
