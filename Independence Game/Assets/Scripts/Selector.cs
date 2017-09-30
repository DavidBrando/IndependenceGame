using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

    public List<GameObject> n;
    private int posicion;

	// Use this for initialization
	void Start () {
        transform.position = n[0].transform.position;
        posicion = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            if(posicion!=0)
            {
                posicion--;
                transform.position = n[posicion].transform.position;
            }      
        }
        else if(Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if(posicion<4)
            {
                posicion++;
                transform.position = n[posicion].transform.position;
            }
        }


        if(Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") <0)
        {
            DecrementarN();
        }
        else if(Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            AumentarN();
        }
	}

    public void AumentarN()
    {
        Text t = n[posicion].GetComponent<Text>();
        int i = int.Parse(t.text);
        if(i<9)
            i++;
        t.text = i.ToString();
    }

    public void DecrementarN()
    {
        Text t = n[posicion].GetComponent<Text>();
        int i = int.Parse(t.text);
        if (i > 0)
            i--;
        t.text = i.ToString();
    }
}
