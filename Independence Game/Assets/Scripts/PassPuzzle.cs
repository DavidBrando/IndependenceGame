using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class PassPuzzle : MonoBehaviour {


    public string solucion;
    public GameObject passUI;
    private bool solucionado;
    public List<GameObject> n;
    private string pass;
    private GamePadState state;
    private GamePadState laststate;

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
	void FixedUpdate () {

        laststate = state;
        state = GamePad.GetState(0);

        if (solucion == pass)
        {
            Solucionado = true;
        }

        ActualizaPass();

        if (Input.GetKeyDown(KeyCode.Escape) || (state.Buttons.B == ButtonState.Pressed && laststate.Buttons.B == ButtonState.Released))
        {
            passUI.SetActive(false);
            GameManager.instance.estadoJuego = GameManager.GameState.ACTIVE;
        }
    }



    void ActualizaPass()
    {
        pass = "";
        n.ForEach(x => pass += x.GetComponent<Text>().text);
    }

    
}
