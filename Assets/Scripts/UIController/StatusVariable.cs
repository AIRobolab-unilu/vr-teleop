using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusVariable : MonoBehaviour {

    private Text[] texts;

    private string variableName;
    public string Name { get { return this.variableName; }
        set { this.variableName = value;
            foreach (var item in this.texts) {
                if (item.name.Equals("Name")) {
                    Debug.Log("HERE " + item.text + " should be "+value);
                    item.text = value;
                }
            }
        } }

    private string variableValue;
    public string Value {
        get { return this.variableValue; }
        set {
            this.variableValue = value;
            foreach (var item in this.texts) {
                if (item.name.Equals("Value")) {
                    item.text = value;
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
    }

    public void Init() {
        this.texts = gameObject.GetComponentsInChildren<Text>();
    }

    

    // Update is called once per frame
    void Update () {
		
	}


    private void OnDestroy() {
        Destroy(gameObject);
    }

}
