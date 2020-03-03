using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour {

    Animator anim;
    AudioSource sound;

    public bool isLoop = false;

	void Start () {

        
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

        if (isLoop)
            InvokeRepeating("playSound", 0.7f, 0.7f);
    }
	
	
    public void playSound()
    {
        if(gameObject.activeSelf)
        {
            sound.Play();
        }
    }
}
