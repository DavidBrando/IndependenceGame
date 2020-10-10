using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour {

    // Use this for initialization

    public float velocidad = 20.0f;
    public float abertura = 15.0f;
    public bool codigo,contact;
    private bool movimiento;
    private bool abierta;
    private float rotY;
    private Vector3 posIni;
    public GameObject panelCodigoUI;
    private PassPuzzle puzzle;

	void Start () {

        movimiento = false;
        abierta = false;
        rotY = transform.rotation.y;
        posIni = transform.position;
        contact = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (movimiento)
        {
            updatePuerta();
        }

        if (Input.GetButtonDown("Interactuar") && contact == true)
        {
            if (!codigo)
                movimiento = true;
            else
            {
                if (!gameObject.GetComponent<PassPuzzle>().enabled)
                    gameObject.GetComponent<PassPuzzle>().enabled = true;

                panelCodigoUI.SetActive(true);
                GameManager.instance.estadoJuego = GameManager.GameState.RESOLVIENDO_PUZZLE;
                if (puzzle.Solucionado)
                {
                    movimiento = true;
                    panelCodigoUI.SetActive(false);
                    GameManager.instance.estadoJuego = GameManager.GameState.ACTIVE;
                }
            }
            // transform.localPosition += Vector3.right * velocidad * Time.deltaTime; 

        }
    }



    public void updatePuerta()
    {

        Debug.Log(tag + " " + movimiento + ": ENTROOOOOO");

        if (this.tag == "puertaCelda")
        {
            if (rotY == 0.0f)
            {
                transform.localPosition += Vector3.left * velocidad * Time.deltaTime;

                if (transform.localPosition.x <= posIni.x - abertura)
                {
                    movimiento = false;
                    abierta = true;
                }

            }

            else if (rotY == 180.0f)
            {

            }

            else if (rotY == 270.0f)
            {

            }
        }

        else if(this.tag == "puertaNivel")
        {
            if (rotY == 0.0f)
            {
                transform.localPosition += Vector3.back * velocidad * Time.deltaTime;

                if (transform.localPosition.z <= posIni.z - abertura)
                {
                    movimiento = false;
                    abierta = true;
                }

            }
        }
    }



    private void OnTriggerEnter(Collider collision)
    {
        if(codigo)
        {
            puzzle = gameObject.GetComponent<PassPuzzle>();
            contact = true;
        }
            
        //collision.
        ////collision.transform.localPosition +=  Vector3.forward;
        //collision.rigidbody.AddRelativeForce(Vector3.down * 5000.0f);

    }

    private void OnTriggerExit(Collider other)
    {
        if(codigo)
        {
            contact = false;
        }
    }
    private void OnTriggerStay(Collider collision)
    {


    }

    public void SetMovimiento(bool x) 
    {
        movimiento = x;
    }
}
