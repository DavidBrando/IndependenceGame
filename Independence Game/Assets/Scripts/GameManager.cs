using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        PAUSE,
        ACTIVE,
        RESOLVIENDO_PUZZLE
    }

    public static GameManager instance=null;
    public GameState estadoJuego;

    float gameTimer = 0.0f;
    int  min, seg;

    GameObject timer;

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
        timer = GameObject.Find("Timer");
	}
	
	// Update is called once per frame
	void Update () {


        //int minutes = Mathf.FloorToInt(timer / 60F);
        //int seconds = Mathf.FloorToInt(timer - minutes * 60);
        //string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        gameTimer += Time.deltaTime;

        min = (int) (gameTimer / 60) % 60;
        seg = (int) (gameTimer % 60);

       string format = string.Format("{0:0}:{1:00}", min, seg);

        timer.GetComponentInChildren<Text>().text = format;

        if(min >= 4)
        {
            timer.GetComponentInChildren<Text>().color = Color.red;
        }
	}
}
