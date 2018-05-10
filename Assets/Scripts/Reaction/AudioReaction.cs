using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReaction : MonoBehaviour {
    private AudioController audioController;
    public AudioClip clip;
    public AudioController.AudioType audioType;
    public bool playOnAwake;
    private void Awake()
    {
        audioController = FindObjectOfType<AudioController>();
        if (playOnAwake)
            React();
    }

    public void React()
    {
        switch(audioType)
        {
            case AudioController.AudioType.SFX:
                audioController.PlaySFX(clip);
                break;
            case AudioController.AudioType.MUSIC:
                audioController.PlayMusic(clip);
                break;
        }
    }
}
