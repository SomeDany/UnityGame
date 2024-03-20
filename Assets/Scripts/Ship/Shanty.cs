using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shanty : MonoBehaviour
{
    public AudioClip[] audioArray;
    public float pauseTime = 30;
    private float nextShanty = 0;
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    
    void Update()
    { 
        if(Time.time > nextShanty )
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                int i = Random.Range(0,audioArray.Length);
                sound.PlayOneShot(audioArray[i]);
                nextShanty = Time.time + pauseTime;        
            } 
        }
    }

}
