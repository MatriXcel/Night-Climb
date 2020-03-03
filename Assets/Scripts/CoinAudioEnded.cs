using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudioEnded : MonoBehaviour {

    new AudioSource audio;

    void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(audio.time >= audio.clip.length)
        {
            GameEntityManager.Instance.returnToPool(gameObject);
        }
	}
}
