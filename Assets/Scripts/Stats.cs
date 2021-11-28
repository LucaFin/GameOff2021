using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    protected float life;
    protected float atkDamage;
    [SerializeField]
    float respawnTime=3f;

    private float OriginalLife;
    private void Start()
    {
        OriginalLife = life;
    }

    public float GetDamage()
    {
        return atkDamage;
    }

    public float GetLife()
    {
        return life;
    }
    public virtual void InflictDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            this.gameObject.SetActive(false);
            if (respawnTime >= 0)
            {
                Invoke("Respawn", respawnTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Respawn()
    {
        PoolEnemy.poolEnemy.Respawn(this.gameObject);
        life = OriginalLife;
    }
}
