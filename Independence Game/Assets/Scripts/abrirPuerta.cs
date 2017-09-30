using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour {

    // Use this for initialization

    public float velocidad = 20.0f;
    public float abertura = 15.0f;
    public bool codigo;
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
	}
	
	// Update is called once per frame
	void Update () {

        if (movimiento)
        {
            updatePuerta();
        }

	}



    private void updatePuerta()
    {

        Debug.Log("ENTROOOOOO");


        if (rotY == 0.0f)
        {
            transform.localPosition += Vector3.left * velocidad * Time.deltaTime;

            if(transform.localPosition.x  <= posIni.x - abertura)
            {
                movimiento = false;
                abierta = true;
            }

        }

        else if(rotY == 180.0f)
        {

        }

        else if(rotY == 270.0f)
        {

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(codigo)
            puzzle = gameObject.GetComponent<PassPuzzle>();
        //collision.
        ////collision.transform.localPosition +=  Vector3.forward;
        //collision.rigidbody.AddRelativeForce(Vector3.down * 5000.0f);

    }

    private void OnCollisionExit(Collision collision)
    {
   

    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetButtonDown("Interactuar"))
        {
           if(!codigo)
                movimiento = true;
           else
            {
               panelCodigoUI.SetActive(true);
               GameManager.instance.estadoJuego = GameManager.GameState.RESOLVIENDO_PUZZLE;
               if(puzzle.Solucionado)
               {
                   movimiento = true;
                   panelCodigoUI.SetActive(false);
                   GameManager.instance.estadoJuego = GameManager.GameState.ACTIVE;
               }
            }
            // transform.localPosition += Vector3.right * velocidad * Time.deltaTime; 

        }

    }
}
