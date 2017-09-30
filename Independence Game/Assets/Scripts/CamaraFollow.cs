using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {


    public float CamaraMoveSpeed = 120.0f;
    public GameObject camaraFollowObj;
    Vector3 followPosition;
    public float clangeAngle = 80.0f; //cuanto va a ver a camara, segun dice el chico del video tutorial que estoy viendo jiji
    public float inputSensitivity = 150.0f;
    public GameObject CamaraObj;
    public GameObject PlayerObj;
    public float camDistXToPlayer;
    public float camDistYToPlayer;
    public float camDistZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    public bool visibilityMouse = false;

    //wow such variables,
    //        many numbers
    //             much information wow




    // Use this for initialization
    void Start () {

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y; rotX = rot.x;

        //esto del cursor es para que no se muestre y se bloquee en la pantalla
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        Cursor.visible = visibilityMouse;

        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = -(inputX + mouseX);
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clangeAngle, clangeAngle);

        Quaternion LocalRotaton = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = LocalRotaton;


    }

    private void LateUpdate()
    {

        CamaraUpdater();

    }

    private void CamaraUpdater()
    {
        //set el objeto a seguir
        Transform target = camaraFollowObj.transform;


        //movemos la camara

        float step = CamaraMoveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //throw new NotImplementedException();
    }
}
