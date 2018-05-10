using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterBattleController : MonoBehaviour
{
    public PlayerData playerData;
    public Animator animator;
    private bool isAttacking;
    private readonly int attackTriggerHash = Animator.StringToHash("attack");
    private readonly int attackSpeedHash = Animator.StringToHash("attackSpeed");
    private readonly int idleStateHash = Animator.StringToHash("IdleAttack");
    public bool IsPointerHover
    {
        set;
        get;
    }
    private AudioController audioController;
    private MonsterController monsterController;
    public AudioClip attackClip;
    public AudioClip hitClip;
    public AudioClip criticalHitClip;

    private void Awake()
    {
        audioController = FindObjectOfType<AudioController>();
        monsterController = FindObjectOfType<MonsterController>();
    }

    private void Start()
    {
        animator.SetLayerWeight(1, 1);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(1).shortNameHash == idleStateHash)
        {
            isAttacking = false;
        }
        if (IsPointerHover && !isAttacking && monsterController.isReady)
        {
            Attack();
        }
    }

    private void Attack()
    {
        isAttacking = true;
        audioController.PlaySFX(attackClip);
        animator.SetFloat(attackSpeedHash, playerData.ASPD);
        animator.SetTrigger(attackTriggerHash);
    }

    public void OnAttackTrigger()
    {
        DamageInfo damageInfo = playerData.DamageInfo;
        monsterController.TakeDamage(damageInfo);
        if (damageInfo.isCriHit)
            audioController.PlaySFX(criticalHitClip);
        else
            audioController.PlaySFX(hitClip);
    }
}
