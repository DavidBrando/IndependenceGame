using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversacionTrigger : MonoBehaviour {

    public bool contact;
    public Conversacion conversacion;

    private void OnCollisionEnter(Collision collision)
    {
        contact = true;
    }

    private void OnTriggerExit(Collider other)
    {
        contact = false;
    }
    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Interactuar") && contact==true)
        {
            FindObjectOfType<ConversacionManager>().EmpiezaConversacion(conversacion);
        }
    }
}
