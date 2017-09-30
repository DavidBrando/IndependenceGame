using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPuzzle : MonoBehaviour {

    public List<GameObject> c;
    public List<Text> t;
    private Rigidbody r1, r2;
    private int solucion, maxl1,maxl2;
    public int respuesta;

	// Use this for initialization
	void Start () {
        r1 = c[0].GetComponent<Rigidbody>();
        r2 = c[1].GetComponent<Rigidbody>();
        //litros1 = (int)r1.mass;
        //litros2 = (int)r2.mass;
        maxl1 = 5;
        maxl2 = 3;
        solucion = 4;
        t[0].text = "C1: " + r1.mass.ToString();
        t[1].text = "C2: " + r2.mass.ToString();
        t[2].text = "";
	}
	
    public void Resolver()
    {
        if (r1.mass == solucion || r2.mass == solucion)
        {
            t[2].text = "CORRECTO";
        }
        else
        {
            t[2].text = "INCORRECTO";
        }
    }

    public void VolcarDcha(int pos)
    {
        if (pos == 0)
        {
            //c[pos].transform.Rotate(Vector3.back * Time.deltaTime, 45.0f);
            if (r1.mass > 0)
            {
                r1.mass--;
                if (r2.mass < 1)
                    t[pos].text = "C1: 0";
                else
                    t[pos].text = "C1: "+r1.mass.ToString();
                if (r2.mass< maxl2)
                {
                    r2.mass++;
                    t[pos+1].text = "C2: "+r2.mass.ToString();
                }
            }
                

        }
        else
        {
            //c[pos].transform.Rotate(Vector3.back * Time.deltaTime, 45.0f);
            if (r2.mass > 0)
            {
                r2.mass--;
                if(r2.mass<1)
                    t[pos].text = "C2: 0" ;
                else
                    t[pos].text ="C2: "+ r2.mass.ToString();
            }
        }
    }

    public void VolcarIzq(int pos)
    {
        if(pos==0)
        {
            //c[pos].transform.Rotate(Vector3.forward*Time.deltaTime, 45.0f);
            if(r1.mass>0)
            {
                r1.mass--;
                if (r1.mass < 1)
                    t[pos].text = "C1: 0";
                else
                    t[pos].text = "C1: "+r1.mass.ToString();
            }
                
            
        }
        else
        {
            //c[pos].transform.Rotate(Vector3.forward * Time.deltaTime, 45.0f);
            if (r2.mass > 0)
            {
                r2.mass--;
                if (r2.mass < 1)
                    t[pos].text = "C2: 0";
                else
                    t[pos].text = r2.mass.ToString();
                if(r1.mass < maxl1)
                {
                    r1.mass++;
                    t[pos-1].text = r1.mass.ToString();
                }
            }
        }

    }

    public void Rellenar(int pos)
    {
        if(pos==0)
        {
            r1.mass = maxl1;
            t[pos].text = "C1: "+r1.mass.ToString();
        }
        else
        {
            r2.mass = maxl2;
            t[pos].text = "C2: "+r2.mass.ToString();
        }
    }
}
