using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour {


    private Image image;
	// Use this for initialization
	void Start () {
        this.image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(this.collider.)
	}

    private void OnTriggerEnter(Collider other) {

        this.image.color = Color.white;

        //Debug.Log(other.gameObject.name);
        InputManager.instance.Select(name);
    }

    private void OnTriggerExit(Collider other) {
        this.image.color = Color.grey;

        //Debug.Log(other.gameObject.name);
        InputManager.instance.Unselect();
    }
}
