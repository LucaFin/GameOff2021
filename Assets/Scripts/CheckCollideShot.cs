using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollideShot : MonoBehaviour
{
    [SerializeField]
    private string target="Enemy";
    [SerializeField]
    private string shooter="Player";
    [SerializeField]
    private bool destroyOnCollide;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(target))
        {
            Stats s = collision.gameObject.GetComponent<Stats>();
            s.InflictDamage(1f);
        }

        if (!collision.gameObject.tag.Equals(shooter) && destroyOnCollide)
        {
            Destroy(this.gameObject, 0.01f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(target))
        {
            Stats s = collision.gameObject.GetComponent<Stats>();
            s.InflictDamage(1f);
        }

        if (!collision.gameObject.tag.Equals(shooter) && destroyOnCollide)
        {
            Destroy(this.gameObject, 0.01f);
        }
    }


}
