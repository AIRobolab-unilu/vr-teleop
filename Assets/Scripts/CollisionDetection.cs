using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {


    private SphereCollider collider;
	// Use this for initialization
	void Start () {
        this.collider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(this.collider.)
	}

    private void OnTriggerEnter(Collider other) {

        Debug.Log(other.gameObject.name);
        InputManager.instance.Select(other.gameObject.name);
    }
}
