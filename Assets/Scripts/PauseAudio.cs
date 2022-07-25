using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour {

    void Start () {
        
    GetComponent<AudioSource>().Stop();
    }

    void Update () {

    }
}