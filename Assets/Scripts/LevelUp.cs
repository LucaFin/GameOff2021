using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerNext;
    public void evolve(Vector3 teleportPosition)
    {
        GameObject evolved=Instantiate<GameObject>(PlayerNext, teleportPosition, Quaternion.identity);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject,5f);
    }
}
