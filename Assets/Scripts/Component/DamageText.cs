using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageText : MonoBehaviour {
    public Text text;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Setup(DamageInfo damageInfo)
    {
        text.text = damageInfo.damage.ToString();
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        if (damageInfo.isCriHit)
            animator.SetLayerWeight(1, 1);
    }
}
