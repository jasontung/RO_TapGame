using UnityEngine;
using UnityEngine.Events;

public class PopUpReaction : MonoBehaviour
{
    private PopUpWindowController popUpWindowController;
    public string message;
    public UnityEvent onWindowConfirm;
    public UnityEvent onWindowClose;

    private void Awake()
    {
        popUpWindowController = FindObjectOfType<PopUpWindowController>();
    }
    
    public void React()
    {
        popUpWindowController.PopUp(message, onWindowConfirm, onWindowClose);
    }
}

