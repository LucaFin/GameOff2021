using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    Dictionary<GameObject, Vector3> pool = new Dictionary<GameObject, Vector3>();
    public static PoolEnemy poolEnemy;

    private void Awake()
    {
        poolEnemy = this;
    }
    public void AddPool(GameObject mob, Vector3 spawn)
    {
        pool.Add(mob, spawn);
    }

    public void Respawn(GameObject mob)
    {
        Vector3 mobPosition;
        pool.TryGetValue(mob, out mobPosition);
        mob.transform.position = mobPosition;
        mob.SetActive(true);
    }
}