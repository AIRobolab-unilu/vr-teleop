using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public HeaderController headerController;
    public ContentController contentController;

    private string motivationStatus;
    private string hadrwareStatus;
    private string motorsStatus;
    private string dialogStatus;



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

    public void DecodeStatus(string status) {
        string[] tokens = status.Split('$');

        this.motivationStatus = tokens[0];
        this.hadrwareStatus = tokens[1];
        this.motorsStatus = tokens[2];
        this.dialogStatus = tokens[3];

    }

    //Show hardware status
    public void StatusLeft() {
        Debug.Log("<color=green>Status Left button pressed</color>");
    }

    //Show emotions status
    public void StatusRight() {
        Debug.Log("<color=green>Status Right button pressed</color>");

        this.headerController.ShowAll();
        this.headerController.SetHeader("Robot emotions");

        this.contentController.Add("Curiosity", "0");
        this.contentController.Add("Frustration", "0");
        this.contentController.Add("Pain", "0");
        this.contentController.Add("Frustration", "0");


    }

    public void CommandsLeft() {
        Debug.Log("<color=green>Commands Left button pressed</color>");
    }

    public void CommandsRight() {
        Debug.Log("<color=green>Commands Right button pressed</color>");
    }

    //Show dialog status
    public void StatusUp() {
        Debug.Log("<color=green>Status Up button pressed</color>");
    }

    //Show motors status
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