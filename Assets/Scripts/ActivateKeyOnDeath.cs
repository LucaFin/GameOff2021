using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKeyOnDeath : MonoBehaviour
{
    [SerializeField]
    GameObject Key;
    private void OnDestroy()
    {
        Key.SetActive(true);
    }
}
