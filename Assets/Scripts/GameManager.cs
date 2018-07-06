using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    //Awake is always called before any Start functions
    void Awake() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame() {

    }

    

    //Update is called every frame.
    void Update() {
        
    }

    public void StatusLeft() {
        Debug.Log("<color=green>Status Left button pressed</color>");
    }

    public void StatusRight() {
        Debug.Log("<color=green>Status Right button pressed</color>");
    }

    public void CommandsLeft() {
        Debug.Log("<color=green>Commands Left button pressed</color>");
    }

    public void CommandsRight() {
        Debug.Log("<color=green>Commands Right button pressed</color>");
    }

    public void StatusUp() {
        Debug.Log("<color=green>Status Up button pressed</color>");
    }

    public void StatusDown() {
        Debug.Log("<color=green>Status Down button pressed</color>");
    }

    public void CommandsUp() {
        Debug.Log("<color=green>Commands Up button pressed</color>");
    }

    public void CommandsDown() {
        Debug.Log("<color=green>Commands Down button pressed</color>");
    }
}