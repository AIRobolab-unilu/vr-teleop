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

    internal void UpLeft() {
        Debug.Log("<color=green>Up Left button pressed</color>");
    }

    internal void UpRight() {
        Debug.Log("<color=green>Up Right button pressed</color>");
    }

    internal void DownLeft() {
        Debug.Log("<color=green>Down Left button pressed</color>");
    }

    internal void DownRight() {
        Debug.Log("<color=green>Down Right button pressed</color>");
    }

    internal void LeftUp() {
        Debug.Log("<color=green>Let Up button pressed</color>");
    }

    internal void LeftDown() {
        Debug.Log("<color=green>Left Down button pressed</color>");
    }

    internal void RightUp() {
        Debug.Log("<color=green>Right Up button pressed</color>");
    }

    internal void RightDown() {
        Debug.Log("<color=green>Right Down button pressed</color>");
    }
}