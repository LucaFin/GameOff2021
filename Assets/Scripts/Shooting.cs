using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject Aim;
    [SerializeField]
    GameObject Bullet;
    GameObject Player;
    [SerializeField]
    float range = 10f;
    bool cooldown = true;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < range && cooldown)
        {
            GameObject shot = Instantiate<GameObject>(Bullet, transform.position, Aim.transform.rotation);
            shot.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 1000f);
        }
    }


}
