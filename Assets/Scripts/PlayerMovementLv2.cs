using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLv2 : PlayerMovement
{
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Time.timeScale > 0)
        {
            Movement();
            Attack();
        }
    }
    public override void Attack()
    {
        xShoot = transform.rotation.x;
        yShoot = transform.rotation.y;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && cooldown)
        {
            StartCoroutine(StartCooldown());

            GameObject shot = Instantiate<GameObject>(Bullet, transform.position + new Vector3(xShoot, yShoot), transform.rotation);
            shot.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 1000f);
        }
    }
}
