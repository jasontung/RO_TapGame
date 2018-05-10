using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly int hitTriggerHash = Animator.StringToHash("hit");
    private readonly int dieTriggerHash = Animator.StringToHash("die");
    public EnemyData enemyData;
    public int currentHealth
    {
        private set;
        get;
    }
    private Animator animator;
    public bool isDead;
    public AudioClip dieClip;
    private AudioController audioController;
    private HealthSlider healthSlider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioController = FindObjectOfType<AudioController>();
        healthSlider = FindObjectOfType<HealthSlider>();
    }

    public void Setup(EnemyData data)
    {
        enemyData = data;
        currentHealth = data.health;
        healthSlider.Setup(data.health);
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        if (isDead)
            return;
        animator.SetTrigger(hitTriggerHash);
        int reduceDamage = enemyData.defence;
        if (damageInfo.isCriHit)
            reduceDamage = 0;
        int newDamage = Mathf.Clamp(damageInfo.damage - reduceDamage, 1, int.MaxValue); 
        currentHealth -= newDamage;
        healthSlider.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            animator.SetTrigger(dieTriggerHash);
            audioController.PlaySFX(dieClip);
        }
    }
}
