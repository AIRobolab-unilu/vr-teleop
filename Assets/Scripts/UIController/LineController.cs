using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour {

    public RectTransform headerRect;

    private LineRenderer lr;
    private RectTransform rect;

	// Use this for initialization
	void Start () {
        this.lr = this.GetComponent<LineRenderer>();
        this.rect = this.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {


        ///Debug.Log(this.rect.rect.x);
        //Debug.Log(this.headerRect.rect);

        //this.lr.SetPosition(0, new Vector3(this.rect.rect.x+ this.rect.rect.width/2, this.rect.rect.y + this.rect.rect.height / 2));
        //this.lr.SetPosition(1, new Vector3(this.headerRect.rect.x + this.rect.rect.width / 2, this.headerRect.rect.y + this.rect.rect.height / 2));


        //this.lr.SetPosition(0, new Vector3(this.rect.rect., this.rect.rect.y + this.rect.rect.height / 2));

        // set first point
        //lr.SetPosition(0, rect.anchoredPosition3D + new Vector3(rect.rect.width / 2, 0, 0));
        // initialize second point
        //lr.SetPosition(1, headerRect.anchoredPosition3D + new Vector3(headerRect.rect.width / 2, 0, 0));

        lr.SetPosition(0, rect.anchoredPosition3D);
        // initialize second point
        lr.SetPosition(1, headerRect.anchoredPosition3D);

        // the distance (and direction) between the two points
        /*Vector3 distance = b.anchoredPosition3D - a.anchoredPosition3D;
        for (float i = 0; i < 1; i += speed / 200) {
            // each frame, advance a fraction of the way
            lr.SetPosition(1, distance * i);
            //yield return null;
        }*/

        //Debug.Log(this.lr.GetPosition(0));

        //Debug.Log(this.lr.GetPosition(1));
    }

    

    internal void Reset() {

    }
}
