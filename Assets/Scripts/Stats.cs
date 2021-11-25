using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    protected float life;
    protected float atkDamage;

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
        life -= damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
