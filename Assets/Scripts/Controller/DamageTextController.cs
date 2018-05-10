using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    public int poolLimit = 10;
    public DamageText damageTextPrefab;
    private DamageText[] damageTextPool;
    private int usingIndex;
    private void Awake()
    {
        damageTextPool = new DamageText[poolLimit];
        for (int i = 0; i < poolLimit; i++)
        {
            damageTextPool[i] = Instantiate(damageTextPrefab, transform);
            damageTextPool[i].gameObject.SetActive(false);
        }
    }

    public void PopUp(DamageInfo damageInfo)
    {
        damageTextPool[usingIndex].transform.SetAsLastSibling();
        damageTextPool[usingIndex].Setup(damageInfo);
        usingIndex = (int)Mathf.Repeat(usingIndex + 1, poolLimit);
    }
}
