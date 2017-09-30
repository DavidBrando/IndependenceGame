using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassPuzzle : MonoBehaviour {


    public string solucion;
    private bool solucionado;
    public List<GameObject> n;
    private string pass;
    
    public bool Solucionado
    {
        get
        {
            return solucionado;
        }

        set
        {
            solucionado = value;
        }
    }

    // Use this for initialization
    void Start () {
        Solucionado = false;
        ActualizaPass();
	}
	
	// Update is called once per frame
	void Update () {

        if (solucion == pass)
        {
            Solucionado = true;
        }

        ActualizaPass();
	}

    void ActualizaPass()
    {
        pass = "";
        n.ForEach(x => pass += x.GetComponent<Text>().text);
    }

    
}
