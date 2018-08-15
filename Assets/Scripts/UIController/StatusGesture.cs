using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusGesture : MonoBehaviour {

    private Image image;
    private Text text;

    private string gesture;
    public string Gesture {
        get { return this.gesture; }
        set {
            this.gesture = value;
            this.text.text = this.gesture;
        }
    }

    // Use this for initialization
    void Start () {

    }

    public void Init() {
        this.image = this.GetComponent<Image>();
        this.text = this.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Select() {
        Color tempColor = this.image.color;
        tempColor.a = 1f;
        this.image.color = tempColor;
    }

    public void Unselect() {
        Color tempColor = this.image.color;
        tempColor.a = 0f;
        this.image.color = tempColor;
    }
}
