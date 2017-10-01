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

    private void OnTriggerStay(Collider other)
    {

        contact = true;
    }
    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Interactuar") && contact==true)
        {
            conversacionUI.GetComponent<ConversacionManager>().EmpiezaConversacion(conversacion);
        }
    }
}
