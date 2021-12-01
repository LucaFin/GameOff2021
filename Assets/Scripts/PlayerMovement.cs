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
    public GameObject Bullet;
    [SerializeField]
    CameraFollowPlayer Camera;
    int xMove = 1;
    int yMove = 0;
    protected float xShoot = 1;
    protected float yShoot = 0;
    int z = 0;
    protected bool cooldown = true;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    bool invincible;
    Color opaque;
    Color transparent;
    PlayerStat playerStat;
    bool switched=false;
    bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        playerStat = GetComponent<PlayerStat>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        opaque = sprite.color;
        transparent = new Color(opaque.r, opaque.g, opaque.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            Movement();
            Attack();
            if (Camera.gameObject.activeInHierarchy)
            {
                Camera.setCameraOnPlayer();
            }
        }
    }

    protected void Movement()
    {
        xMove = 0;
        yMove = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            yMove = 1;
            xMove = 0;
            yShoot = 1;
            xShoot = 0;
            z = 90;
            trigger = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            yMove = -1;
            xMove = 0;
            yShoot = -1;
            xShoot = 0;
            z = -90;
            trigger = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            yMove = 0;
            xMove = -1;
            yShoot = 0;
            xShoot = -1;
            z = -180;
            sprite.flipX = true;
            trigger = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            yMove = 0;
            xMove = 1;
            yShoot = 0;
            xShoot = 1;
            z = 0;
            sprite.flipX = false;
            trigger = true;
        }
        if (switched)
        {
            int app;
            app = yMove;
            yMove = xMove;
            xMove = app;
            yMove *= -1;
        }
        rb.velocity = new Vector2(xMove, yMove) * force;
    }

    public virtual void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && cooldown)
        {
            StartCoroutine(StartCooldown());
            if (switched && trigger)
            {
                float app;
                app = yShoot;
                yShoot = xShoot;
                xShoot = app;
                yShoot *= -1;
                trigger = false;
                z -= 90;
            }
            GameObject shot = Instantiate<GameObject>(Bullet, transform.position + new Vector3(xShoot, yShoot), Quaternion.identity);
            shot.transform.rotation = Quaternion.Euler(0, 0, z);
            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(xShoot, yShoot) * 1000f);
        }
    }

    protected IEnumerator StartCooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(shotTime);
        cooldown = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<Stats>().GetDamage());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<Stats>().GetDamage());
        }
    }

    public void setSwitched(bool flag)
    {
        switched = flag;
    }
    private IEnumerator Invincible()
    {
        invincible = true;
        for (int i = 0; i < 8; i++)
        {
            sprite.color = sprite.color.a == 0 ? opaque : transparent;
            yield return new WaitForSeconds(0.3f);
        }
        sprite.color = opaque;
        invincible = false;

    }

    private void TakeDamage(float damage)
    {
        if (!invincible)
        {
            playerStat.InflictDamage(damage);
            StartCoroutine(Invincible());
        }
    }

    public void RefreshCollider()
    {
        Destroy(GetComponent<PolygonCollider2D>());
        if (this.gameObject.GetComponent<CircleCollider2D>() == null)
        {
            this.gameObject.AddComponent<CircleCollider2D>();
            this.gameObject.GetComponent<CircleCollider2D>().radius = 0.8f;
        }
    }
}
