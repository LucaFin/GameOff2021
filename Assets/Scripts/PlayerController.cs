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
    private bool invincible=false;
    private Color opaque;
    private Color transparent;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        opaque = spriteRenderer.color;
        transparent = new Color(opaque.r, opaque.g, opaque.b, 0f);
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
            TakeDamage(1f);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(inputValue*force*Time.deltaTime, false, jump);
        jump = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(1f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(1f);
        }
    }

    private IEnumerator Invincible()
    {
        invincible = true;
        for(int i=0;i<8;i++)
        {
            spriteRenderer.color = spriteRenderer.color.a == 0 ? opaque : transparent;
            yield return new WaitForSeconds(0.3f);
        }
        spriteRenderer.color = opaque;
        invincible = false;
        
    }

    private void TakeDamage(float damage)
    {
        if (!invincible)
        {
            PlayerStat.playerStat.InflictDamage(damage);
            StartCoroutine(Invincible());
        }
    }
}
