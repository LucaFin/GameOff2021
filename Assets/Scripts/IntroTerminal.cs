using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTerminal : MonoBehaviour
{

    //Game state
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
        Terminal.WriteLine("Welcome to ");
    }

}
