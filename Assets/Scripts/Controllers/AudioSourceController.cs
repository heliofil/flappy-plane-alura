using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    
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

  
}
