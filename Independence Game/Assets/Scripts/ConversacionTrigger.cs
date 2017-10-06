using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversacionTrigger : MonoBehaviour {

    public bool contact;
    public Conversacion conversacion;
    public GameObject conversacionUI;

    private void OnTriggerEnter(Collider other)
    {
        contact = true;
    }

    private void OnTriggerExit(Collider other)
    {
        contact = false;
    }


    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Interactuar") && contact==true && GameManager.instance.estadoJuego != GameManager.GameState.RESOLVIENDO_PUZZLE)
        {
            conversacionUI.GetComponent<ConversacionManager>().EmpiezaConversacion(conversacion);
        }
    }
}
