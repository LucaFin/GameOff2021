using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Keyboard.canWrite = true;
    }

    void ShowMainMenu() //Funzione per visualizzare il terminale   
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Welcome to aMazeBug game..");
        Terminal.WriteLine(@"
                  \_/
                 (* *)
                __)#(__
               ( )...( )(_)
               || |_| ||//
            >==() | | ()/
                _(___)_
               [-]   [-]
  ");
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
        }

    }
}
