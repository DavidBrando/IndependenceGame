using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class Selector : MonoBehaviour {

    public List<GameObject> n;
    private int posicion;
    public string tipo;
    public GameObject wp,mm,cm;
    private GamePadState state;
    private GamePadState laststate;
    public PlayerIndex playerIndex = 0;


    // Use this for initialization
    void Start () {
        if(tipo!="conversacion")
        {
            transform.position = n[0].transform.position;
            posicion = 0;
        }

        
	}
	
	// Update is called once per frame
	void Update () {


        laststate = state;
        state = GamePad.GetState(playerIndex);
        //state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left
        if (tipo == "numeros")
        {
            if ((Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0 ) || (state.DPad.Left == ButtonState.Pressed && laststate.DPad.Left == ButtonState.Released) )
            {
                if (posicion != 0)
                {
                    posicion--;
                    transform.position = n[posicion].transform.position;
                }
            }
            else if ((Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0) || (state.DPad.Right == ButtonState.Pressed && laststate.DPad.Right == ButtonState.Released))
            {
                if (posicion < 4)
                {
                    posicion++;
                    transform.position = n[posicion].transform.position;
                }
            }


            if ((Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0) || (state.DPad.Down == ButtonState.Pressed && laststate.DPad.Down == ButtonState.Released))
            {
                DecrementarN();
            }
            else if ((Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0) || (state.DPad.Up == ButtonState.Pressed && laststate.DPad.Up == ButtonState.Released))
            {
                AumentarN();
            }
        }

        if(tipo == "agua")
        {
            if ((Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0) || (state.DPad.Left == ButtonState.Pressed && laststate.DPad.Left == ButtonState.Released))
                {
                if (posicion != 0)
                {
                    posicion--;
                    transform.position = n[posicion].transform.position;
                }
            }
            else if ((Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0) || (state.DPad.Right == ButtonState.Pressed && laststate.DPad.Right == ButtonState.Released))
            {
                if (posicion < 1)
                {
                    posicion++;
                    transform.position = n[posicion].transform.position;
                }
            }


            if(Input.GetKeyDown(KeyCode.Alpha1) || (state.Buttons.LeftShoulder == ButtonState.Pressed && laststate.Buttons.LeftShoulder == ButtonState.Released))
            {
                VolcarIzq();
            }

            if(Input.GetKeyDown(KeyCode.Alpha2) || (state.Buttons.RightShoulder == ButtonState.Pressed && laststate.Buttons.RightShoulder == ButtonState.Released))
            {
                VolcarDcha();
            }

            if(Input.GetMouseButtonDown(0) || (state.Buttons.A == ButtonState.Pressed && laststate.Buttons.A == ButtonState.Released))
            {
                Rellenar();
            }



            if (Input.GetButtonDown("Interactuar") || (state.Buttons.X == ButtonState.Pressed && laststate.Buttons.X == ButtonState.Released))
            {
                wp.GetComponent<WaterPuzzle>().Resolver();
            }
        }

        if (tipo == "colores")
        {
            if ((Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0) || (state.DPad.Left == ButtonState.Pressed && laststate.DPad.Left == ButtonState.Released))
            {
                if (posicion != 0)
                {
                    posicion--;
                    transform.position = n[posicion].transform.position;
                }
            }
            else if ((Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0) || (state.DPad.Right == ButtonState.Pressed && laststate.DPad.Right == ButtonState.Released))
            {
                if (posicion < 4)
                {
                    posicion++;
                    transform.position = n[posicion].transform.position;
                }
            }


            if ((Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0) || (state.DPad.Down == ButtonState.Pressed && laststate.DPad.Down == ButtonState.Released))
            {
                CambiaColor(1);
            }
            else if ((Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0) || (state.DPad.Up == ButtonState.Pressed && laststate.DPad.Up == ButtonState.Released))
            {
                CambiaColor(-1);
            }

            if (Input.GetButtonDown("Interactuar") || (state.Buttons.X == ButtonState.Pressed && laststate.Buttons.X == ButtonState.Released))
            {
                mm.GetComponent<Mastermind>().Resolver();
            }
        }

        //if(tipo == "conversacion")
        //{
        //    if(Input.GetKeyDown(KeyCode.F) || (state.Buttons.A == ButtonState.Pressed && laststate.Buttons.A == ButtonState.Released))
        //    {
        //        cm.GetComponent<ConversacionManager>().SiguienteFrase();
        //    }
        //}
    }

    public void AumentarN()
    {
        Text t = n[posicion].GetComponent<Text>();
        int i = int.Parse(t.text);
        if(i<9)
            i++;

        else if (i == 9)
            i = 0;

        t.text = i.ToString();
    }

    public void DecrementarN()
    {
        Text t = n[posicion].GetComponent<Text>();
        int i = int.Parse(t.text);

        if (i > 0)
            i--;

        else if (i == 0)
            i = 9;

        t.text = i.ToString();

    }

    public void VolcarDcha()
    {
        wp.GetComponent<WaterPuzzle>().VolcarDcha(posicion);
    }

    public void VolcarIzq()
    {
        wp.GetComponent<WaterPuzzle>().VolcarIzq(posicion);
    }

    public void Rellenar()
    {
        wp.GetComponent<WaterPuzzle>().Rellenar(posicion);
    }

    public void CambiaColor(int o)
    {
        mm.GetComponent<Mastermind>().CambiaColor(posicion, o);
    }

    private void OnEnable()
    {
        if(tipo!="conversacion")
        {
            transform.position = n[0].transform.position;
            posicion = 0;
        }
        
    }
}
