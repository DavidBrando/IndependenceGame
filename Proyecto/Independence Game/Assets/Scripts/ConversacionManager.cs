using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class ConversacionManager : MonoBehaviour {

    private Queue<string> frases;
    public Text textoConver;
    public GameObject uiConversacion;
    

    // Use this for initialization
    void Start () {
        frases = new Queue<string>();
        uiConversacion.SetActive(false);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) )
        {
            SiguienteFrase();
        }
    }

    private void OnEnable()
    {
        if(frases!=null)
            frases.Clear();
        else
            frases = new Queue<string>();
    }

    public void EmpiezaConversacion(Conversacion conver)
    {
        

        uiConversacion.SetActive(true);

        //activa el panel que contiene el texto de la conversacion


        //encola las distintas frases de la conversacion
        foreach (string s in conver.dialogo)
        {
            frases.Enqueue(s);
        }
        

        SiguienteFrase();
    }


    public void SiguienteFrase()
    {
        Debug.Log("TAMAÑO: " + frases.Count);
        if(frases.Count==0)
        {
            FinConversacion();
            return;
        }

        Debug.Log("jajajaaj " + frases.Count);
        string frase = frases.Dequeue();
        Debug.Log("desencolo " + frases.Count);
        StopAllCoroutines();
        StartCoroutine(EscribeFrase(frase));
    }

    public void FinConversacion()
    {
        uiConversacion.SetActive(false);
    }

    IEnumerator EscribeFrase(string f)
    {
        
        textoConver.text = "";
        foreach(char c in f.ToCharArray())
        {
            textoConver.text += c;
            yield return null;
        }
        Debug.Log("En la corrutina " + frases.Count);
    }
}
