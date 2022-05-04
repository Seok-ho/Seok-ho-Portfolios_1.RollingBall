using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour
{
    AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
        song.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
