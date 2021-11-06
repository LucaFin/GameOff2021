using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController2D controller;
    [SerializeField]
    private float force;
    [SerializeField]
    private GameObject shot;
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
        jump = Input.GetButtonDown("Jump");
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject bullet = Instantiate<GameObject>(shot,transform.position,Quaternion.identity);
            float direction = transform.localScale.x < 0 ? -1 : 1;
            Vector3 scale = bullet.transform.localScale;
            bullet.transform.localScale = new Vector3(scale.x*direction, scale.y, scale.z);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction*200f,0));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerStat.playerStat.InflictDamage(1f);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(inputValue*force*Time.deltaTime, false, jump);
        jump = false;

    }
}
