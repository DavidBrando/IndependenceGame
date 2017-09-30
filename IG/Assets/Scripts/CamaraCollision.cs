﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraCollision : MonoBehaviour {

    public float minDist = 1.0f;
    public float maxDist = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

	// Use this for initialization
	void Awake () {

        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;

	}
	
	// Update is called once per frame
	void Update () {


        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDist);
        RaycastHit hit;

        if(Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)){
            distance = Mathf.Clamp((hit.distance * 0.9f), minDist, maxDist);
        }

        else{
            distance = maxDist;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
