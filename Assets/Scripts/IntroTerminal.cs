using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTerminal : MonoBehaviour
{

    //Game state
    string input, input1;
    [SerializeField] Terminal connectedToTerminal;
    enum Screen { MainMenu, Start, BUG };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        input1 = ("Questo e un testo di prova");
        ShowStory(input1);
        ShowMainMenu();
    }


    //TEST
    //

    private void ShowStory(string s)
    {
        string ns = s + '\n';
        foreach (char c in s)
        {
            connectedToTerminal.ReceiveFrameInput(c.ToString());
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
            }
            
        }
    }

    //
    //

    void ShowMainMenu() //Funzione per visualizzare il terminale   
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Welcome to ");
    }

    void OnUserInput(string input)
    {
        input = input.ToLower();
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "show")
        {
            ShowStory(input1);
        }
    }
}
