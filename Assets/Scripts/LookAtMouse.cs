using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class LookAtMouse : MonoBehaviour
{
    Vector2 mousePosition;
    Vector2 LookDir;
    Rigidbody2D rb;
    float angle;
    Camera cam;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("Camera3").GetComponent<Camera>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (cam.gameObject.activeInHierarchy)
        {
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);
            LookDir = mousePosition - rb.position;
            angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation=angle;
        }

    }
}
