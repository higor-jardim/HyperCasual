using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelper : MonoBehaviour


{
    public KeyCode keycode = KeyCode.P;
    public AudioSource audioSource;

    void Update()
    {
        if(Input.GetKeyDown(keycode))
       {
        Play();
       }

    }
    public void Play()
    {
        audioSource.Play();
    }
}
