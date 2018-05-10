using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBehavior : MonoBehaviour {
    public Component targetType;
    public bool onlyDestroyComponent;
    private void Awake()
    {
        if (FindObjectsOfType(targetType.GetType()).Length > 1)
        {
            if (onlyDestroyComponent)
            {
                Destroy(targetType);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
