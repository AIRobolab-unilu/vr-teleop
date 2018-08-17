using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class DialogController : MonoBehaviour {

    public GameObject alternatives;
    public GameObject optionnals;
    public GameObject answer;
    public GameObject question;
    public Text title;

    private Text text;
    private CanvasGroup canvasGroup;

    private GameObject alternative;
    private List<GameObject> alternativesGO;

    private GameObject optionnal;
    private List<GameObject> optionnalsGO;

    private bool firstAlternative = true;
    private bool firstOptionnal = true;

    // Use this for initialization
    void Start () {
        this.canvasGroup = gameObject.GetComponent<CanvasGroup>();
        //this.text = this.gameObject.GetComponentInChildren<Text>();

        this.alternative = GameObject.Find("Alternative");
        this.alternativesGO = new List<GameObject>();
        this.alternativesGO.Add(this.alternative);

        this.optionnal = GameObject.Find("Option");
        this.optionnalsGO = new List<GameObject>();
        this.optionnalsGO.Add(this.optionnal);

        this.HideAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddAlternative(string text) {

        GameObject ui;

        if (this.firstAlternative) {
            this.firstAlternative = false;

            ui = this.alternative;

        }
        else {
            ui = Instantiate(this.alternative, this.alternatives.transform, true);
            this.alternativesGO.Add(ui);

        }

        ui.transform.SetParent(this.alternatives.transform, false);
        ui.GetComponentInChildren<Text>().text = text;

        
    }

    public void AddOptionnal(string text) {

        GameObject ui;

        if (this.firstOptionnal) {
            this.firstOptionnal = false;

            ui = this.optionnal;

        }
        else {
            ui = Instantiate(this.optionnal, this.optionnals.transform, true);
            this.optionnalsGO.Add(ui);

        }

        ui.transform.SetParent(this.optionnals.transform, false);
        ui.GetComponentInChildren<Text>().text = text;


    }

    public void SetHeader(string text) {
        this.text.text = text;
    }

    public void HideAll() {
        this.canvasGroup.alpha = 0;
    }

    public void ShowAll(string title) {
        this.title.text = title;
        this.canvasGroup.alpha = 1;
    }

    public void Reset() {

        this.answer.GetComponent<UILineConnector>().transforms[1] = this.question.GetComponent<RectTransform>();

        this.firstAlternative = true;
        foreach (GameObject entry in this.alternativesGO) {

            if (firstAlternative) {
                entry.GetComponentInChildren<Text>().text = "";
                firstAlternative = false;
                continue;

            }
            else {
                Destroy(entry);
            }

            
            
        }
        this.firstAlternative = true;

        this.alternativesGO = new List<GameObject>();
        this.alternativesGO.Add(this.alternative);

        this.optionnalsGO = new List<GameObject>();
        this.optionnalsGO.Add(this.optionnal);

        this.answer.GetComponentInChildren<Text>().text = "";
        this.question.GetComponentInChildren<Text>().text = "";

    }

    public void SetStatus(string question, string mode, string answer, string alternatives, string optionals, string chosen) {

        this.Reset();

        this.question.GetComponentInChildren<Text>().text = question;

        if (!alternatives.Equals("")) {
            foreach (string item in alternatives.Split('/')) {
                
                this.AddAlternative(this.CombineAlternative(item));
            }
        }

        //Debug.Log(!optionals.Equals(""));

        if (!optionals.Equals("")) {
            foreach (string item in optionals.Split('/')) {
                this.AddOptionnal(item);
            }
        }

        this.answer.GetComponentInChildren<Text>().text = answer;

        string[] part = chosen.Split('/');
        GameObject alternative = this.alternativesGO[Int32.Parse(part[0])];
        GameObject optionnal = this.optionnalsGO[Int32.Parse(part[1])];

        //foreach (GameObject item in this.alternativesGO) {


        //if (this.CombineAlternative(chosen).Equals(alternative.GetComponentInChildren<Text>().text)){
        
        foreach (GameObject tmp in this.optionnalsGO) {
            Debug.Log(tmp);
            Debug.Log(optionnal);
            optionnal.GetComponent<UILineConnector>().transforms[1] = alternative.transform.Find("Bot Anchor").GetComponent<RectTransform>();
        }

        this.answer.GetComponent<UILineConnector>().transforms[1] = optionnal.transform.Find("Bot Anchor").GetComponent<RectTransform>();



        //this.answer.GetComponent<UILineConnector>().transforms[1] = item.transform.Find("Bot Anchor").GetComponent<RectTransform>();
        //Debug.Log("I've found " + item);
        //break;
        //}
        //}
    }

    private string CombineAlternative(string alternative) {
        string[] part = alternative.Split('$');
        return part[0] + " with " + part[1];
    }
    
}
