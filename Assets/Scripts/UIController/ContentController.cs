using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour {

    private Text[] texts;
    private Dictionary<string, StatusVariable> variables;
    private GameObject variable;

    private bool first = true;

    // Use this for initialization
    void Start () {
        this.variables = new Dictionary<string, StatusVariable>();
        this.variable = GameObject.Find("Variable");

        //this.Add("test", "re");

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(string text, string value) {

        GameObject ui;

        if (this.first) {

            ui = this.variable;

            this.first = false;

        }
        else {
            
            ui = Instantiate(this.variable, this.transform, true);
            
        }


        StatusVariable tmp = ui.GetComponent<StatusVariable>();
        tmp.Init();

        this.variables.Add(text, tmp);

        tmp.Name = text;
        tmp.Value = value;


        //this.SetNameAndValue(ui, text, value);
        

        ui.transform.SetParent(this.transform, false);

        //gameObject.AddComponent()
        //this.text.text = text;
    }

    /*private void SetNameAndValue(GameObject gameObject, string name, string value) {
        Text[] tmp = gameObject.gameObject.GetComponentsInChildren<Text>();

        //Text variableName;
        //Text variableValue;

        foreach (var item in tmp) {
            if (item.name.Equals("Name")) {
                item.text = name;
            }
            if (item.name.Equals("Value")) {
                item.text = value;
            }
        }
    }*/

    public void UpdateValue(string text, string value) {
        //this.values.Add(text, value);
        if (this.variables.ContainsKey(text)) {
            this.variables[text].Value = value;
        }
        else {
            this.Add(text, value);
        }
        
    }

    public void Reset() {
        //GameObject[] gameObjects = Getch
        bool first = true;
        this.first = true;

        foreach (KeyValuePair<string, StatusVariable> entry in this.variables) {
            if (first) {
                entry.Value.Name = "No value to display";
                entry.Value.Value = "";
                first = false;
                continue;

            }

            Destroy(entry.Value);
            
        }

        this.variables = new Dictionary<string, StatusVariable>();


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
