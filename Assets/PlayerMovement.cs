using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float force = 1f;
    [SerializeField]
    float shotTime = 1f;
    [SerializeField]
    GameObject Bullet;
    int x=1;
    int y=0;
    int z = 0;
    bool cooldown = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * force;
            y = 1;
            x = 0;
            z = 90;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * Time.deltaTime * force;
            y = -1;
            x = 0;
            z = -90;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime * force;
            y = 0;
            x = -1;
            z = -180;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * force;
            y = 0;
            x = 1;
            z = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && cooldown)
        {
            StartCoroutine(StartCooldown());
            GameObject shot = Instantiate<GameObject>(Bullet, transform.position, Quaternion.identity);
            shot.transform.rotation = Quaternion.Euler(0, 0, z);
            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y)*1000f);
        }

    }

    IEnumerator StartCooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(shotTime);
        cooldown = true;
    }
}
