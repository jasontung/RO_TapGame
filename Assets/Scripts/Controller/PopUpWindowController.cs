using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PopUpWindowController : MonoBehaviour
{
    public UIFader uiFader;
    public float fadeDuration = 0.5f;
    public Text messageText;
    private UnityEvent onConfirm;
    private UnityEvent onClose;
    
    private void Start()
    {
        StartCoroutine(uiFader.Fade(0, 0, false));
    }

    public void PopUp(string message, UnityEvent onWindowConfirm = null, UnityEvent onWindowClose = null)
    {
        StartCoroutine(uiFader.Fade(1, fadeDuration, true));
        messageText.text = message;
        onConfirm = onWindowConfirm;
        onClose = onWindowClose;
    }

    public void OnButtonClick(bool result)
    {
        StartCoroutine(uiFader.Fade(0, fadeDuration, false));
        if(result)
            onConfirm.Invoke();
        else
            onClose.Invoke();
        onConfirm = null;
        onClose = null;
    }
}
