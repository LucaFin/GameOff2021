using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Vector2 PlayerPosition;
    Vector2 LookDir;
    Rigidbody2D rb;
    float angle;
    Camera cam;
    GameObject Player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player")) {
            if (go.activeSelf)
            {
                Player = go;
            }
        }
    }
    // Update is called once per frame
    private void Update()
    {
        PlayerPosition = Player.transform.position;
    }
    void FixedUpdate()
    {
       
        LookDir = PlayerPosition - rb.position;
        angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
