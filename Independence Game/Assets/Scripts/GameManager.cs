using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        PAUSE,
        ACTIVE,
        RESOLVIENDO_PUZZLE
    }

    public static GameManager instance=null;
    public GameState estadoJuego;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        estadoJuego = GameState.ACTIVE;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
