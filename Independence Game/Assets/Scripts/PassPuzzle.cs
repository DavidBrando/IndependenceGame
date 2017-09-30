using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassPuzzle : MonoBehaviour {


    public string solucion;
    public List<GameObject> n;
    public string pass;

	// Use this for initialization
	void Start () {
        ActualizaPass();
	}
	
	// Update is called once per frame
	void Update () {

        if (solucion == pass)
        {
            Debug.Log("Solucion correcta");
        }

        ActualizaPass();
	}

    void ActualizaPass()
    {
        pass = "";
        n.ForEach(x => pass += x.GetComponent<Text>().text);
    }
}
