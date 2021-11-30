using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : Stats
{
    [SerializeField]
    GameObject explosion;
    public override void InflictDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            explosion.SetActive(true);
            explosion.GetComponent<Animator>().Play("EnemyExplosionLv1");
            Invoke("Disable",0.4f);
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        ComponentHandler.componentHandler.Unlock();
    }
}
