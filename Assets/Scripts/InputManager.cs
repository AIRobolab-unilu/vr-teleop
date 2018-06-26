using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public CanvasGroup rootGroup;

    public CanvasGroup topGroup;
    public CanvasGroup bottomGroup;
    public CanvasGroup leftGroup;
    public CanvasGroup rightGroup;

    private bool activated = false;
    private string deeplyActivated = "";

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
        this.HideAll();
    }

    private void HideAll() {
        this.Hide(this.rootGroup);
        this.Hide(this.topGroup);
        this.Hide(this.bottomGroup);
        this.Hide(this.leftGroup);
        this.Hide(this.rightGroup);
    }

    private void Reset() {
        this.HideAll();
        this.activated = false;
        this.deeplyActivated = "";
    }


    void Hide(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    void Show(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space")) {
            this.Show(this.rootGroup);
             this. activated = !this.activated;
        }
        if (this.activated) {
            if (Input.GetKeyDown("up")) {
                if (this.deeplyActivated.Equals("left")) {
                    GameManager.instance.UpLeft();
                    this.Reset();
                }
                else if (this.deeplyActivated.Equals("right")) {
                    GameManager.instance.UpRight();
                    this.Reset();
                }
                else {
                    this.Show(this.topGroup);
                    this.deeplyActivated = "up";
                }
            }
            if (Input.GetKeyDown("down")) {
                if (this.deeplyActivated.Equals("left")) {
                    GameManager.instance.DownLeft();
                    this.Reset();
                }
                else if (this.deeplyActivated.Equals("right")) {
                    GameManager.instance.DownRight();
                    this.Reset();
                }
                else {
                    this.Show(this.bottomGroup);
                    this.deeplyActivated = "down";
                }
                
            }
            if (Input.GetKeyDown("left")) {
                if (this.deeplyActivated.Equals("up")) {
                    GameManager.instance.LeftUp();
                    this.Reset();
                }
                else if (this.deeplyActivated.Equals("down")) {
                    GameManager.instance.LeftDown();
                    this.Reset();
                }
                else {
                    this.Show(this.leftGroup);
                    this.deeplyActivated = "left";
                }
                
            }
            if (Input.GetKeyDown("right")) {
                if (this.deeplyActivated.Equals("up")) {
                    GameManager.instance.RightUp();
                    this.Reset();
                }
                else if (this.deeplyActivated.Equals("down")) {
                    GameManager.instance.RightDown();
                    this.Reset();
                }
                else {
                    this.Show(this.rightGroup);
                    this.deeplyActivated = "right";
                }
                
            }
        }
        

    }
}
