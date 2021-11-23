using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollideShot : MonoBehaviour
{
    [SerializeField]
    private string target="Enemy";
    [SerializeField]
    private string shooter="Player";
    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(target))
        {
            Stats s = collision.gameObject.GetComponent<Stats>();
            s.InflictDamage(1f);
        }

        if (!collision.gameObject.tag.Equals(shooter))
        {
            Destroy(this.gameObject);
        }
    }
}
