using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {


    private Text text;
    private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
        this.canvasGroup = gameObject.GetComponent<CanvasGroup>();
        //this.text = this.gameObject.GetComponentInChildren<Text>();

        this.HideAll();
	}
	
	// Update is called once per frame
	void Update () {
		
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
