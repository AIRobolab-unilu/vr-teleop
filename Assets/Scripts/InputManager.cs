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
    private bool movedCursorGesture = false;

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

        if (this.statusActivated) {
            this.status.RemoveDescription();
        }
        else if (this.commandsActivated) {
            this.commands.RemoveDescription();
        }
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

        string buttonName = "";

        if (this.statusActivated) {
            buttonName = "Status";
        }
        else if (this.commandsActivated) {
            buttonName = "Commands";
        }

        

        string title = GameManager.instance.GetTitleFromButton(buttonName + name);

        if (this.statusActivated) {
            this.status.SetDescription(title);
        }
        else if (this.commandsActivated) {
            this.commands.SetDescription(title);
        }

        Debug.Log(title);
       
    }

    // Update is called once per frame
    void Update () {

        OVRInput.Update();
        
        //Debug.Log(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch));
        //Debug.Log(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));

        //Debug.Log(OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch));
        //Debug.Log(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));


        //To display the status buttons
        if (/*Input.GetKeyDown("left") ||*/ Input.GetButtonDown("Fire3") || OVRInput.GetDown(OVRInput.Button.Three)) {
            Debug.Log("Show status");

            this.statusActivated = true;
            this.commandsActivated = false;
            this.commands.Reset();

            this.status.ShowAll();
            //this.cursor.GetComponent<CanvasGroup>().alpha = 1;
            //this.cursor.SetActive(true);
        }

        //To display the commands buttons
        if (/*Input.GetKeyDown("right") ||*/ Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.One)) {
            Debug.Log("Show commands");

            this.commandsActivated = true;
            this.statusActivated = false;
            this.status.Reset();

            this.commands.ShowAll();
            //this.cursor.GetComponent<CanvasGroup>().alpha = 1;
            //this.cursor.SetActive(true);
            
            
        }

        //To select a button
        if (this.selected != null && (Input.GetButtonDown("Trigger Left") || Input.GetButtonDown("Trigger Right") || Input.GetKeyDown("space") ||
                OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))) {


            this.status.RemoveDescription();
            this.commands.RemoveDescription();

            if (this.statusActivated) {
                if (this.selected.Equals("Left")) {
                    GameManager.instance.StatusLeft();
                }
                else if (this.selected.Equals("Top")) {
                    GameManager.instance.StatusTop();
                }
                else if (this.selected.Equals("Right")) {
                    GameManager.instance.StatusRight();
                }
                else if (this.selected.Equals("Bottom")) {
                    GameManager.instance.StatusBottom();
                }

            }

            if (this.commandsActivated) {
                if (this.selected.Equals("Left")) {
                    GameManager.instance.CommandsLeft();
                }
                else if (this.selected.Equals("Top")) {
                    GameManager.instance.CommandsTop();
                }
                else if (this.selected.Equals("Right")) {
                    GameManager.instance.CommandsRight();
                }
                else if (this.selected.Equals("Bottom")) {
                    GameManager.instance.CommandsBottom();
                }
            }

            this.statusActivated = false;
            this.commandsActivated = false;
            this.status.Reset();
            this.commands.Reset();
            this.selected = null;

        }

        if (GameManager.instance.GestureNavigation) {
            if(Input.GetAxis("Vertical") > 0.9f && !this.movedCursorGesture) {
                GameManager.instance.gesturesController.SelectUp();
                this.movedCursorGesture = true;
                Debug.Log("up");
            } else if (Input.GetAxis("Vertical") < -0.9f && !this.movedCursorGesture) {
                GameManager.instance.gesturesController.SelectDown();
                this.movedCursorGesture = true;
            } else if (Input.GetAxis("Vertical") < 0.9f && Input.GetAxis("Vertical") > -0.9f) {
                this.movedCursorGesture = false;
            }
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
