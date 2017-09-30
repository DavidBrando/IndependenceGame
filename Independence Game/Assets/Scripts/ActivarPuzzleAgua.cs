using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPuzzleAgua : MonoBehaviour {

    public bool contact;
    public GameObject panelPuzzleAguaUI;
    private WaterPuzzle wp;
    public Camera cam1, cam2;
    public GameObject puerta;

    private void Start()
    {
        contact = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        contact = true;
        wp = gameObject.GetComponent<WaterPuzzle>();
    }

    private void OnTriggerExit(Collider other)
    {
        contact = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Interactuar") && this.contact == true && GameManager.instance.estadoJuego!= GameManager.GameState.RESOLVIENDO_PUZZLE)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            panelPuzzleAguaUI.SetActive(true);
            GameManager.instance.estadoJuego = GameManager.GameState.RESOLVIENDO_PUZZLE;
        }

        if(wp!=null && wp.t[2].text == "CORRECTO")
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
            panelPuzzleAguaUI.SetActive(false);
            wp.t[2].text = "Solucionado";
            GameManager.instance.estadoJuego = GameManager.GameState.ACTIVE;
        }
    }
}
