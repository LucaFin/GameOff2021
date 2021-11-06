using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollideShot : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 20f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Stats s = collision.gameObject.GetComponent<Stats>();
            s.InflictDamage(1f);
        }

        if (!collision.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
