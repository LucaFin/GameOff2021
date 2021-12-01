using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
    public GameObject pnlPause;
    public AudioSource BackgroundAudio;
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
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToMain()
    {
        SceneManager.LoadScene("IntroScene");
        if (isPaused)
        {
            ChangePauseStatus();
        }
    }
    void UpdateGamePause()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            BackgroundAudio.Pause();
        }
        else
        {
            Time.timeScale = 1;
            BackgroundAudio.Play();
        }
        pnlPause.SetActive(isPaused);
    }
}
