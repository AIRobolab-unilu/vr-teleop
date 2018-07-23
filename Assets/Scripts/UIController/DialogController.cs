using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {


    private Text text;
    private CanvasGroup canvasGroup;
    private GameObject alternative;
    private GameObject content;

    // Use this for initialization
    void Start () {
        this.canvasGroup = gameObject.GetComponent<CanvasGroup>();
        //this.text = this.gameObject.GetComponentInChildren<Text>();

        this.alternative = GameObject.Find("Alternative");
        this.content = GameObject.Find("Content");

        this.HideAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddAlternative(string text) {
        GameObject ui = Instantiate(this.alternative, this.content.transform, true);
        ui.SetActive(true);
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

    internal void Reset() {

    }
}
