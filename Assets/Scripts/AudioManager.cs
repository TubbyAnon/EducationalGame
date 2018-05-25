using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // the audio clip
    public AudioClip MusicClip;

    // the component that Unity uses to play your clip
    public AudioSource MusicSource;

	void Start () {
        MusicSource.clip = MusicClip;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MusicSource.Play();	
	}
}
