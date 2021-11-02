using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController2D controller;
    [SerializeField]
    private float force;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(force,false,false);
    }
}
