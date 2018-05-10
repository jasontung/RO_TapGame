using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackTriggerReaction : MonoBehaviour {
    public UnityEvent onTriggerAttack;
	public void React()
    {
        onTriggerAttack.Invoke();
    }
}
