using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float force = 1f;
    [SerializeField]
    float shotTime = 1f;
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    CameraFollowPlayer Camera;
    int xMove = 1;
    int yMove = 0;
    int xShoot = 1;
    int yShoot = 0;
    int z = 0;
    bool cooldown = true;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = 0;
        yMove = 0;
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            yMove = 1;
            xMove = 0;
            yShoot = 1;
            xShoot = 0;
            z = 90;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            yMove = -1;
            xMove = 0;
            yShoot = -1;
            xShoot = 0;
            z = -90;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            yMove = 0;
            xMove = -1;
            yShoot = 0;
            xShoot = -1;
            z = -180;
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            yMove = 0;
            xMove = 1;
            yShoot = 0;
            xShoot = 1;
            z = 0;
            sprite.flipX = false;
        }
        rb.velocity = new Vector2(xMove, yMove) * force;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && cooldown)
        {
            StartCoroutine(StartCooldown());
            GameObject shot = Instantiate<GameObject>(Bullet, transform.position+new Vector3(xShoot,yShoot), Quaternion.identity);
            shot.transform.rotation = Quaternion.Euler(0, 0, z);
            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(xShoot, yShoot) *1000f);
        }
        Camera.setCameraOnPlayer();
    }

    IEnumerator StartCooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(shotTime);
        cooldown = true;
    }
}
