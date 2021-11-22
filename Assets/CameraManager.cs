using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CameraManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> cameras;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[2].SetActive(true);
        }
    }
}
