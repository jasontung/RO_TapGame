using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    private const float CRITICAL_HIT_MULTIPLE = 1.5f;
    public int atk;
    public int agi;
    public int luk;
    public float ASPD
    {
        get
        {
            return (float)agi / 10;
        }
    }
    public Vector2 damageFloatRange = Vector2.one;
    public DamageInfo DamageInfo
    {
        get
        {
            DamageInfo damageInfo = new DamageInfo();
            damageInfo.isCriHit = Random.value * 100 <= luk;
            float attackProportion = Random.Range(damageFloatRange.x, damageFloatRange.y);
            float damage = atk * attackProportion;
            if (damageInfo.isCriHit)
                damage *= CRITICAL_HIT_MULTIPLE;
            damageInfo.damage = Mathf.FloorToInt(damage);
            return damageInfo;
        }
    }
}

public struct DamageInfo
{
    public int damage;
    public bool isCriHit;
}
