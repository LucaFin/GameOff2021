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
            loadCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            loadCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            loadCamera(2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            loadCamera(3);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            loadCamera(4);
        }
    }

    public void loadCamera(int index)
    {
        foreach (GameObject camera in cameras)
        {
            camera.SetActive(false);
        }
        cameras[index].SetActive(true);
    }
}
