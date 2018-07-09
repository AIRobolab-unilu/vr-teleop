using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour {

    private Text[] texts;
    private Dictionary<string, string> values;
    private GameObject variable;

    private bool first = true;

    // Use this for initialization
    void Start () {
        this.values = new Dictionary<string, string>();
        this.variable = GameObject.Find("Variable");

        //this.Add("test", "re");

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(string text, string value) {

        GameObject ui;

        if (this.first) {
            this.first = false;

            ui = this.variable;

        }
        else {
            this.values.Add(text, value);
            ui = Instantiate(this.variable, this.transform, true);
        }
        

        Text[] tmp = ui.gameObject.GetComponentsInChildren<Text>();

        //Text variableName;
        //Text variableValue;

        foreach (var item in tmp) {
            if (item.name.Equals("Name")) {
                item.text = text;
            }
            if (item.name.Equals("Value")) {
                item.text = value;
            }
        }

        ui.transform.SetParent(this.transform, false);

        //gameObject.AddComponent()
        //this.text.text = text;
    }

    public void UpdateValue(string text, string value) {
        this.values.Add(text, value);
    }
}
