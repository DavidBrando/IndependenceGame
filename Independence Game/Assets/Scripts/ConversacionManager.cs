﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class ConversacionManager : MonoBehaviour {

    private Queue<string> frases;
    public Text textoConver;
    public GameObject uiConversacion;
    public Animator anim;
    private GamePadState state;
    private GamePadState laststate;


    // Use this for initialization
    void Start () {
        frases = new Queue<string>();
	}

    private void OnEnable()
    {
        frases = new Queue<string>();
    }
    public void EmpiezaConversacion(Conversacion conver)
    {

        uiConversacion.SetActive(true);
        frases.Clear();

        //activa el panel que contiene el texto de la conversacion
        

        //encola las distintas frases de la conversacion
        conver.dialogo.ForEach(x => frases.Enqueue(x));

        SiguienteFrase();
    }


    public void SiguienteFrase()
    {
        if(frases.Count==0)
        {
            FinConversacion();
            return;
        }

        string frase = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(EscribeFrase(frase));
    }

    public void FinConversacion()
    {
        uiConversacion.SetActive(false);
    }

    IEnumerator EscribeFrase(string f)
    {
        foreach(char c in f.ToCharArray())
        {
            textoConver.text += c;
            yield return null;
        }
    }
}
