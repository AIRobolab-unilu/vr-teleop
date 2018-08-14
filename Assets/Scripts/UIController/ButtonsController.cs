using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour {

    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    public GameObject cursor;

    public Text description;

    private Dictionary<string, GameObject> match =
            new Dictionary<string, GameObject>();


    public void Awake() {
        this.match.Add("top", top);
        this.match.Add("bottom", bottom);
        this.match.Add("left", left);
        this.match.Add("right", right);

        //this.cursor.transform.position = this.transform.position;

        this.HideAll();
    }

    private void Update() {
        Vector3 position = new Vector3(125 * Input.GetAxis("Horizontal"),
                +125 * Input.GetAxis("Vertical"),
                0);

        this.cursor.transform.localPosition = position;
        
        //Debug.Log("me : " + transform.position);
    }

    private void Hide(GameObject image) {
        image.SetActive(false);
    }

    private void Show(GameObject image) {
        image.SetActive(true);
    }

    public void SetDescription(string description) {
        this.description.text = description;
    }

    public void RemoveDescription() {
        this.description.text = "";
    }

    public void HideAll() {

        //this.gameObject.SetActive(false);

        this.Hide(top);
        this.Hide(bottom);
        this.Hide(left);
        this.Hide(right);

        this.Hide(cursor);
    }

    public void ShowAll() {

        //this.gameObject.SetActive(true);


        this.Show(top);
        this.Show(bottom);
        this.Show(left);
        this.Show(right);

        this.Show(cursor);
    }

    public void Reset() {
        this.HideAll();
        this.left.GetComponent<Image>().color = Color.grey;
        this.right.GetComponent<Image>().color = Color.grey;
        this.top.GetComponent<Image>().color = Color.grey;
        this.bottom.GetComponent<Image>().color = Color.grey;
    }
}
