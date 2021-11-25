using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Pathfinding.AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
