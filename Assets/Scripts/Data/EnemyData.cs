using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public int health = 100;
    public int defence;
    public Enemy enemyPrefab;

    public Enemy Init(Transform root)
    {
        Enemy enemy = Instantiate(enemyPrefab, root);
        enemy.Setup(this);
        return enemy;
    }
}
