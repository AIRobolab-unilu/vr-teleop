using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class DialogController : MonoBehaviour {

    public GameObject answers;
    public GameObject answer;
    public GameObject question;

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

            ui = Instantiate(this.alternative, this.answers.transform, true);

        }

        ui.transform.SetParent(this.answers.transform, false);
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

        this.answer.GetComponentInChildren<Text>().text = "";
        this.question.GetComponentInChildren<Text>().text = "";

    }

    public void SetStatus(string question, string mode, string answer, string alternatives, string optionals, string chosen) {

        this.Reset();

        this.question.GetComponentInChildren<Text>().text = question;

        if (!alternatives.Equals("")) {
            foreach (string item in alternatives.Split('/')) {

                this.AddAlternative(item);
            }
        }

        //Debug.Log(!optionals.Equals(""));

        if (!optionals.Equals("")) {
            foreach (string item in optionals.Split('/')) {

                this.AddAlternative(item);
            }
        }

        this.answer.GetComponentInChildren<Text>().text = answer;

        foreach(GameObject item in this.alternatives) {
            if (item.GetComponentInChildren<Text>().text.Equals(chosen)){
                this.answer.GetComponent<UILineConnector>().transforms[1] = item.GetComponent<RectTransform>();
                break;
            }
        }
    }
    
}
