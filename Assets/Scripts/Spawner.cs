using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float numberOfSpawned = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < numberOfSpawned; i++)
        {
            GameObject mob = Instantiate<GameObject>(prefab, transform.position, Quaternion.identity);
            PoolEnemy.poolEnemy.AddPool(mob,this.transform.position);
            yield return new WaitForSeconds(spawnRate);
        }
    }


}
