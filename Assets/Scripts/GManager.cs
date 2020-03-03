using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {

    public static GManager instance = null;
    
    public float HighScore  {get; private set;}
     
    float currScore;

    public int ScoreMultiplier { get; set; }

    public float CurrScore
    {
        get
        {
            return Mathf.RoundToInt(currScore);
        }

        private set{ }       
    }

    public int Coins {get; private set;}
    public int CurrCoins{get; private set;}
    

    public enum GameState {resume, pause, restart, other, gameover};
    public GameState currState;


    public float PowerDuration = 3;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        currState = GameState.resume;

    }
	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("Coins") != null)
            Coins = PlayerPrefs.GetInt("Coins");
        else
        {
            PlayerPrefs.SetInt("Coins", 0);
            Coins = 0;
        }

        if (PlayerPrefs.GetFloat("HighScore") != null)
            HighScore = PlayerPrefs.GetFloat("HighScore");
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
            HighScore = 0;
        }

       

        currState = GameState.resume;

	}
	
	// Update is called once per frame
	void Update () {
        if(currState == GameState.resume)
            CalculateScore();
	}


    public void CalculateScore()
    {
        float toadd;
        toadd = (Time.deltaTime) * ScoreMultiplier;
        currScore += toadd;
    }

    public void SaveScores()
    {
        if (currScore > HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", currScore);
        }
    }



    public void AddCoins()
    {
        CurrCoins +=1; 
    }

    public void SaveCoins()
    {
       Coins += CurrCoins;
       PlayerPrefs.SetInt("Coins", Coins);
    }

    public bool DeduceCoins(int deduce)
    {
        if (Coins < deduce)
            return false;
        Coins -= deduce;
        PlayerPrefs.SetInt("Coins", Coins);
        return true;
    }


    public void PauseGame()
    {
        currState = GameState.pause;
        Time.timeScale = 0;

    }
    public void ContinueGame()
    {
        currState = GameState.resume;
        Time.timeScale = 1;
    }
   
    public void RestartGame()
    {
        currState = GameState.restart;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.LoadLevel("Level");
        currState = GameState.resume;
        CurrCoins = 0;
        currScore = 0;
    }

    public void GameOver()
    {
        currState = GameState.gameover;
        //RestartGame();
        //SceneManager.LoadScene("ScoreMenu");
    }

    public void OtherGame()
    {
        currState = GameState.other;
    }

    public void HandleState()
    {
        if (currState == GameState.pause)
            ContinueGame();
        else if (currState == GameState.resume)
            PauseGame();

    }


}
