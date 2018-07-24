using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    public GameObject content;

    private Text text;
    private CanvasGroup canvasGroup;

    private GameObject alternative;
    private List<GameObject> alternatives;
    
    private bool first = true;

    // Use this for initialization
    void Start () {
        this.canvasGroup = gameObject.GetComponent<CanvasGroup>();
        //this.text = this.gameObject.GetComponentInChildren<Text>();

        this.alternative = GameObject.Find("Alternative");

        this.alternatives = new List<GameObject>();

        this.HideAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddAlternative(string text) {

        GameObject ui;

        if (this.first) {
            this.first = false;

            ui = this.alternative;

        }
        else {

            ui = Instantiate(this.alternative, this.content.transform, true);

        }

        ui.transform.SetParent(this.content.transform, false);
        ui.GetComponentInChildren<Text>().text = text;

        this.alternatives.Add(ui);
    }

    public void SetHeader(string text) {
        this.text.text = text;
    }

    public void HideAll() {
        this.canvasGroup.alpha = 0;
    }

    public void ShowAll() {
        this.canvasGroup.alpha = 1;
    }

    public void Reset() {

        foreach (GameObject entry in this.alternatives) {
            if (first) {
                entry.GetComponentInChildren<Text>().text = "";
                first = false;
                continue;

            }

            Destroy(entry);
            

        }

        this.alternatives = new List<GameObject>();


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
}
