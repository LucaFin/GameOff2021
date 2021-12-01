using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    protected float life;
    [SerializeField]
    protected float atkDamage=1;
    [SerializeField]
    float respawnTime=3f;
    [SerializeField]
    private GameObject prefab;
    private GameObject explosion;
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
            if (prefab != null)
            {
                explosion = Instantiate<GameObject>(prefab, transform.position, Quaternion.identity);
            }
            if (respawnTime >= 0)
            {
                Invoke("Respawn", respawnTime);
                Invoke("DestroyPrefab", 2f);
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


    private void DestroyPrefab()
    {
        Destroy(explosion);
    }
}
