using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stats
{
    
    public static PlayerStat playerStat;

    private void Awake()
    {
        playerStat = this;
    }

    public new void InflictDamage(float damage)
    {
        UIManager.uIManager.HeartDamage(damage);
        life -= damage;
    }
}
