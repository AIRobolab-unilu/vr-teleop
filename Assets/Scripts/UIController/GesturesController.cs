using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GesturesController : MonoBehaviour {

    private List<StatusGesture> gestures;
    private GameObject gesture;

    private bool first = true;
    private int selected = 0;

    private int maxDisplay = 10;

    // Use this for initialization
    void Start () {

        this.gestures = new List<StatusGesture>();
        this.gesture = GameObject.Find("Gesture");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(string value) {
        Debug.Log("adding " + value);

        GameObject ui;

        if (this.first) {

            ui = this.gesture;


        }
        else {

            ui = Instantiate(this.gesture, this.transform, true);

        }

        StatusGesture tmp = ui.GetComponent<StatusGesture>();
        tmp.Init();

        if (this.first) {
            tmp.Select();

            this.first = false;
        }
        else {
            tmp.Unselect();
        }

        this.gestures.Add(tmp);

        if(this.gestures.Count > this.maxDisplay) {
            ui.SetActive(false);
        }

        tmp.Gesture = value;


        //this.SetNameAndValue(ui, text, value);


        ui.transform.SetParent(this.transform, false);

        //gameObject.AddComponent()
        //this.text.text = text;
    }


    public void SelectDown() {
        
        this.gestures[this.selected].Unselect();
        //this.gestures[this.selected].gameObject.SetActive(false);

        this.selected += 1;
        if (this.selected > this.gestures.Count - 1) {
            this.selected = 0;

            if (!this.gestures[this.selected].gameObject.activeSelf) {

                for (int i = 0; i < this.maxDisplay; i += 1) {
                    this.gestures[this.gestures.Count - i-1].gameObject.SetActive(false);
                    this.gestures[i].gameObject.SetActive(true);
                }
            }
        }

        if (!this.gestures[this.selected].gameObject.activeSelf) {
            this.gestures[this.selected - this.maxDisplay - 1].gameObject.SetActive(false);
            this.gestures[this.selected].gameObject.SetActive(true);
        }

        this.gestures[this.selected].Select();

    }

    public void SelectUp() {
        this.gestures[this.selected].Unselect();

        this.selected -= 1;
        if (this.selected < 0) {

            this.selected = this.gestures.Count - 1;

            if (!this.gestures[this.selected].gameObject.activeSelf) {
                
                for (int i = 0; i < this.maxDisplay; i += 1) {
                    this.gestures[this.selected - i].gameObject.SetActive(true);
                    this.gestures[i].gameObject.SetActive(false);
                }
            }

            
        }

        if (!this.gestures[this.selected].gameObject.activeSelf) {

            this.gestures[this.selected + this.maxDisplay + 1].gameObject.SetActive(false);
            this.gestures[this.selected].gameObject.SetActive(true);

            
        }

        this.gestures[this.selected].Select();
    }

    public void Reset() {
        //GameObject[] gameObjects = Getch
        bool first = true;
        this.first = true;

        foreach (StatusGesture gesture in this.gestures) {
            if (first) {
                gesture.Gesture = "No value to display";
                first = false;
                continue;

            }

            //Destroy(gesture, 0f);
            Debug.Log("destroying " + gesture);
            gesture.DestroyGO();

        }

        this.gestures = new List<StatusGesture>();
        this.selected = 0;


    /*foreach (Transform child in transform) {
        if (first) {
            this.SetNameAndValue(child.gameObject, "No value to display", "");

            first = false;
            continue;
        }
        Destroy(child.gameObject);
        this.variables = new Dictionary<string, StatusVariable>();
        this.first = true;
    }*/


}

    public string GetSelected() {
        return this.gestures[this.selected].Gesture;
    }
}
