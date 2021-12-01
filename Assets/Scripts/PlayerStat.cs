using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stats
{
    public override void InflictDamage(float damage)
    {
        UIManager.uIManager.HeartDamage(damage);
        life -= damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public override void ResetLife()
    {
        base.ResetLife();
        UIManager.uIManager.ResetLife();

    }
}
