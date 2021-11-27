using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTerminal : MonoBehaviour
{

    //Game state
    string input;
    [SerializeField] Terminal connectedToTerminal;
    enum Screen { MainMenu, Start, BUG };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
        ShowStory("Main Menu" + '\n' + "Write space to Play" + '\n');
        Keyboard.canWrite = true;
    }

    void ShowMainMenu() //Funzione per visualizzare il terminale   
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine(@"
                  \_/
                 (* *)
                __)#(__
               ( )...( )(_)
               || |_| ||//
            >==() | | ()/
                _(___)_
    Welcome to [-] a [-] MazeBug game
  ");
    }

    private void ShowStory(string s)
    {
        string ns = s + '\n';

        StartCoroutine(Story(s));

    }

    IEnumerator Story(string s)
    {
        yield return new WaitForSeconds(2f);
        foreach (char c in s)
        {
            connectedToTerminal.ReceiveFrameInput(c.ToString());
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnUserInput(string input)
    {
        if (input != null)
        {
            input = input.ToLower();
            if (input == "menu")
            {
                ShowMainMenu();
            }
            if (input == "space")
            {
                SceneManager.LoadScene(1);
            }
        }

    }
}
