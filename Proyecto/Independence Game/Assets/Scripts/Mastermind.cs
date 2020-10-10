using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mastermind : MonoBehaviour {

    public List<Image> casillas, resultado;
    public List<Color> colores;
    public List<Color> respuesta;//deberia de ser privada pero se queda public para hacer pruebas
    private bool solucionado;

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
        colores = new List<Color>();
        respuesta = new List<Color>();
        colores.Add(Color.red);
        colores.Add(Color.blue);
        colores.Add(Color.yellow);
        colores.Add(Color.green);
        

        //respuesta generada de forma aleatoria
        respuesta.Add(colores[Random.Range(0, 3)]);
        respuesta.Add(colores[Random.Range(0, 3)]);
        respuesta.Add(colores[Random.Range(0, 3)]);
        respuesta.Add(colores[Random.Range(0, 3)]);
    }

    private void OnEnable()
    {
        if(colores!=null)
        {
            casillas.ForEach(x => x.color = Color.grey);
            resultado.ForEach(x => x.color = Color.grey);
        }
    }


    public void CambiaColor(int pos,int orientacion)
    {
        int i = colores.FindIndex(x => x == casillas[pos].color);
        i += orientacion;
        if(i <0)
        {
            i = colores.Count - 1;
        }
        else if(i>colores.Count)
        {
            i = 0;
        }
        Debug.Log(i);
        casillas[pos].color = colores[i];
    }

    public void Resolver()
    {
        int acierto = 0;
        List<Color> c = new List<Color>();
        casillas.ForEach(x => c.Add(x.color));

        for(int i=0;i<c.Count;i++)
        {
            if (c[i] == respuesta[i])
            {
                resultado[i].color = Color.black;
            }
            else if (respuesta.Contains(c[i]))
            {
                resultado[i].color = Color.white;
            }
            else
                resultado[i].color = Color.gray;
        }

        if(resultado.FindAll(x => x.color == Color.black).Count==resultado.Count)
        {
            solucionado = true;
            Debug.Log("XAXAXAXA");
        }
    }
}
