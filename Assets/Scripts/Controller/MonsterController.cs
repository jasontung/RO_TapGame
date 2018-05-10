using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterController : MonoBehaviour {
    private Enemy enemyInstance;
    public float delayNextEnemyTime = 0.5f;
    private YieldInstruction delayNextEnemyInstruction;
    public EnemyData[] enemys;
    private int curEnemyIndex = -1;
    public Transform root;
    private DamageTextController damageTextController;
    public bool isReady
    {
        private set;
        get;
    }

    private void Awake()
    {
        delayNextEnemyInstruction = new WaitForSeconds(delayNextEnemyTime);
        damageTextController = FindObjectOfType<DamageTextController>();
    }

    private void Start()
    {
        GetNextEnemy();
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        damageTextController.PopUp(damageInfo);
        enemyInstance.TakeDamage(damageInfo);
        if (enemyInstance.isDead)
        {
            isReady = false;
            StartCoroutine(WaitEnemyDead());
        }
    }

    private IEnumerator WaitEnemyDead()
    {
        yield return delayNextEnemyInstruction;
        Destroy(enemyInstance);
        GetNextEnemy();
    }
    
    public void GetNextEnemy()
    {
        curEnemyIndex = (int)Mathf.Repeat(curEnemyIndex + 1, enemys.Length);
        enemyInstance = enemys[curEnemyIndex].Init(root);
        isReady = true;
    }
}
