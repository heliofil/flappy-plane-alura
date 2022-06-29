using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{

    public MovimentScriptable velocity;
    
    private AudioSource audioSource;
    public static AudioSource Instance {
        get; private set;
    }

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Instance = audioSource; 

    }

    private void FixedUpdate() {
        SetPitch();
    }

    void SetPitch() {
        audioSource.pitch = velocity.Value*10;
    }


}
