using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text ScoreText;
    public Text CoinText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text =  GManager.instance.CurrScore.ToString();
        CoinText.text = GManager.instance.CurrCoins.ToString();
	}

}
