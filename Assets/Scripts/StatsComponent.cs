using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : Stats
{
    public override void InflictDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            this.gameObject.SetActive(false);
            ComponentHandler.componentHandler.Unlock();
        }
    }
}
