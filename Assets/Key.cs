using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    float livelloCompletato;
    [SerializeField]
    List<GameObject> spawner= new List<GameObject>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {

        PoolEnemy.poolEnemy.ClearPool();
        if (livelloCompletato == 1)
        {
            Debug.Log("inserire animazione apertura porta");
        }
        if (livelloCompletato == 2)
        {
            Debug.Log("inserire animazione apertura porta");
        }
        if (livelloCompletato == 3)
        {
            Debug.Log("inserire animazione apertura porta");
        }
        foreach (GameObject spawn in spawner)
        {
            spawn.SetActive(true);
        }
    }
}
