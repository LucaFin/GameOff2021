using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public int width;
    public int height;

    private void Start()
    {
        Screen.SetResolution(width, height, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadMaze1();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadMaze2();
        }
        if (Input.GetKeyDown(KeyCode.E)){
            LoadMaze3();
        }
    }
    public void LoadMaze1()
    {
        
        SceneManager.LoadScene("Maze1");
    }
    public void LoadMaze2()
    {
        SceneManager.LoadScene("Maze2");
    }
    public void LoadMaze3()
    {
        SceneManager.LoadScene("Maze3");
    }
    public void LoadMaze4()
    {
        SceneManager.LoadScene("Maze1");
    }
}
