using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTerminal : MonoBehaviour
{

    //Game state
    string input;
    [SerializeField] Terminal connectedToTerminal;
    [SerializeField] float terminalSpeed=0.05f;
    enum Screen { MainMenu, Start, BUG };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu() //Funzione per visualizzare il terminale   
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("\n");
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
        ShowStory("\n\n\n\n\n\n\n\n\n\n Main Menu" + '\n' + "0. Write 'start' to play;" + '\n' + "1. Write 'menu' to reload main menu;" + '\n' + "2. Write 'story' to read story;" + '\n' + "3. Write 'quit' to close the game;" + '\n');
    }

    private void ShowStory(string s)
    {
        string ns = s + '\n';

        StartCoroutine(Story(s));

    }

    IEnumerator Story(string s)
    {
        Keyboard.canWrite = false;
        yield return new WaitForSeconds(2f);
        foreach (char c in s)
        {
            connectedToTerminal.ReceiveFrameInput(c.ToString());
            yield return new WaitForSeconds(terminalSpeed);
        }
        Keyboard.canWrite = true;
    }

    void OnUserInput(string input)
    {
        if (input != null)
        {
            input = input.ToLower();
            if (input == "menu")
            {
                Keyboard.canWrite = false;
                ShowMainMenu();
                Keyboard.canWrite = true;
            }
            if (input == "start")
            {
                SceneManager.LoadScene(1);
            }
            if (input == "story")
            {
                Keyboard.canWrite = false;
                Terminal.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
                ShowStory(@"The story behind the scene
An artificial intelligence wants to    materialize in the real world but to do so it needs the prison of circuits that surrounds it to be destroyed, so it     creates a virus that will have to be    guided in its mission through amazing   evolutions.

One of its forms will be:              'First actual case of bug being found'               Note from Lt.Grace Hopper
Who knows what shape it is...         
Write 'menu' to return or 'story' to   repeat.
");

                Keyboard.canWrite = true;
            }
            if (input == "quit")
            {
                Application.Quit();
            }
            if (input == "moth")
            {
                SceneManager.LoadScene(2);
            }
        }

    }
}
