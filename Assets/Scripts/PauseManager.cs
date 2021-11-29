using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
    public GameObject pnlPause;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) //Se viene premuto esc
        {
            ChangePauseStatus();
        }
    }

    public void ChangePauseStatus()
    {
        isPaused = !isPaused;
        UpdateGamePause();
    }

    public void ResetGames()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ChangePauseStatus();
    }

    public void returnToMain()
    {
        SceneManager.LoadScene("IntroScene");
        ChangePauseStatus();
    }
    void UpdateGamePause()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        pnlPause.SetActive(isPaused);
    }
}
