using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stats
{
    public new void InflictDamage(float damage)
    {
        UIManager.uIManager.HeartDamage(damage);
        life -= damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
