using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    /// <summary>
    /// Scripts that manages all UI buttons  , add extra buttons the same way
    /// </summary>

    AudioSource audiosrc;
    public AudioClip ButtonSFX;


    public void Awake()
    {
        audiosrc = GetComponent<AudioSource>();
        if(Application.loadedLevelName == "Level")
            BackgroundMusicManager.Instance.SetGameMusic();
        else
        BackgroundMusicManager.Instance.SetMenuAudio();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
        //Application.LoadLevel("Level"); 
    }

    public void Back()
    {
        Debug.Log("Go Back");
    }

    public void Pause()
    {
        GManager.instance.HandleState();
    }


    public void LoadScene(string SceneName)
    {
            StartCoroutine(DelayedLoad(SceneName));
    }

    IEnumerator DelayedLoad(string SceneName)
    {
        //code necessary for when button press sound will be added
        audiosrc.pitch = Random.Range(0.8f,1.2f);
        audiosrc.PlayOneShot(ButtonSFX);
        yield return new WaitForSeconds(ButtonSFX.length);
        //yield return new WaitForSeconds(0.5f);
        Application.LoadLevel(SceneName);

    }



}
