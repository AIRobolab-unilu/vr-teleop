using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public ButtonsController status;
    public ButtonsController commands;
    

    //public GameObject cursor;

    private bool statusActivated = false;
    private bool commandsActivated = false;
    private Vector3 initialPosition;

    private string selected;

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

    public void Unselect() {
        this.selected = null;
    }

    //Initializes the game for each level.
    void InitGame() {
        //this.initialPosition = new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z);
        //Debug.Log("saving " + this.initialPosition);
        this.HideAll();
    }

    private void HideAll() {
        this.status.HideAll();
        this.commands.HideAll();

        //this.cursor.GetComponent<CanvasGroup>().alpha = 0;
        //this.cursor.SetActive(false);
    }

    public void Select(string name) {


        this.selected = name;

        if (this.statusActivated) {

            if (name.Equals("Left")) {
                GameManager.instance.StatusLeft();
            }
            else if (name.Equals("Top")) {
                GameManager.instance.StatusUp();
            }
            else if (name.Equals("Right")) {
                GameManager.instance.StatusRight();
            }
            else if (name.Equals("Bottom")) {
                GameManager.instance.StatusDown();
            }
            
        }

        if (this.commandsActivated) {
            if (name.Equals("Left")) {
                GameManager.instance.StatusLeft();
            }
            else if (name.Equals("Top")) {
                GameManager.instance.CommandsUp();
            }
            else if (name.Equals("Right")) {
                GameManager.instance.CommandsRight();
            }
            else if (name.Equals("Bottom")) {
                GameManager.instance.CommandsDown();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("left") || Input.GetButtonDown("Fire3")) {
            Debug.Log("Show");
            this.status.ShowAll();
            //this.cursor.GetComponent<CanvasGroup>().alpha = 1;
            //this.cursor.SetActive(true);
            this.statusActivated = true;
        }
        if (Input.GetKeyDown("right") || Input.GetButtonDown("Fire1")) {
            Debug.Log("Show");
            this.commands.ShowAll();
            //this.cursor.GetComponent<CanvasGroup>().alpha = 1;
            //this.cursor.SetActive(true);
            this.commandsActivated = true;
        }

        if (this.selected != null && (Input.GetButtonDown("Trigger Left") || Input.GetButtonDown("Trigger Right"))) {

            this.commands.HideAll();
        }

        /*if (this.statusActivated) {

            Vector3 position = new Vector3(13 * Input.GetAxis("Horizontal"),
                + 13 * Input.GetAxis("Vertical"),
                0);

            //this.status.SetCursor(position);

            //Debug.Log(cursor.GetComponent<RectTransform>().position);
            //cursor.transform.position = position;

            //cursor.GetComponent<RectTransform>().position = position;
            //Debug.Log(Input.GetAxis("Horizontal"));
            //Debug.Log(Input.GetAxis("Vertical"));
        }

        if (this.commandsActivated) {
            Vector3 position = new Vector3(13 * Input.GetAxis("Horizontal"),
                +13 * Input.GetAxis("Vertical"),
                0);

            //this.status.SetCursor(position);
            //Debug.Log(cursor.GetComponent<RectTransform>().position);
            //cursor.transform.position = position;
            //cursor.GetComponent<RectTransform>().position = position;
            //Debug.Log(Input.GetAxis("Horizontal Right"));
            //Debug.Log(Input.GetAxis("Vertical Right"));
        }*/
        
    }
    
}
