using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour {

    public Text HighScoreText;
    public Text CurrentScoreText;
    public Text FactText;

    public string[] Facts;


	// Use this for initialization
	void Start () {
        HighScoreText.text = GManager.instance.HighScore.ToString();
        CurrentScoreText.text = GManager.instance.CurrScore.ToString();
        FactText.text = Facts[Random.Range(0, Facts.Length)];
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        GManager.instance.RestartGame();
    }

    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    }




}
