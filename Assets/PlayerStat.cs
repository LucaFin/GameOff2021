using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    private float life;
    private float atkDamage;
    public static PlayerStat playerStat;

    private void Awake()
    {
        playerStat = this;
    }

    public float GetDamage()
    {
        return atkDamage;
    }

    public float GetLife()
    {
        return life;
    }

    public void InflictDamage(float damage)
    {
        UIManager.uIManager.HeartDamage(damage);
        life -= damage;
    }
}
