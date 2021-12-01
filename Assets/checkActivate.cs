using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkActivate : MonoBehaviour
{
    [SerializeField]
    List<GameObject> factory;

    private void OnDisable()
    {
        bool flag=false;
        foreach(GameObject go in factory)
        {
            if (go.activeInHierarchy)
            {
                flag = true;
            }
        }
        if (!flag)
        {
            PoolEnemy.poolEnemy.ClearPool();
        }
    }
}
