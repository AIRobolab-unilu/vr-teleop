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

    private Dictionary<string, GameObject> match =
            new Dictionary<string, GameObject>();


    public void Awake() {
        this.match.Add("top", top);
        this.match.Add("bottom", bottom);
        this.match.Add("left", left);
        this.match.Add("right", right);

        this.cursor.transform.position = this.transform.position;

        this.HideAll();
    }


    private void Hide(GameObject image) {
        image.SetActive(false);
    }

    private void Show(GameObject image) {
        image.SetActive(true);
    }

    public void HideAll() {
        this.Hide(top);
        this.Hide(bottom);
        this.Hide(left);
        this.Hide(right);

        this.Hide(cursor);
    }

    public void ShowAll() {
        this.Show(top);
        this.Show(bottom);
        this.Show(left);
        this.Show(right);

        this.Show(cursor);
    }
}
