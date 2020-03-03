using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour {

    public AudioClip MenuBackground;
    public AudioClip[] GameBackground;

    public static BackgroundMusicManager Instance;

    AudioSource audio;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }

        audio = GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGameMusic()
    {
        audio.clip = GameBackground[Random.Range(0, GameBackground.Length)];
        audio.Play();
    }

    public void SetMenuAudio()
    {
        if (audio.clip.name != MenuBackground.name)
        {
            audio.clip = MenuBackground;
            audio.Play();
        }

    }





}
