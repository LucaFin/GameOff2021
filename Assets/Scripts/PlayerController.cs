using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController2D controller;
    [SerializeField]
    private float force;
    private float inputValue;
    private bool jump;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        controller.Move(inputValue*force*Time.deltaTime, false, jump);
        jump = false;
    }
}
