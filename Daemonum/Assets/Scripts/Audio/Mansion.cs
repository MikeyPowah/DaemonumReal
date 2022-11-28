using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mansion : MonoBehaviour
{
    public AudioClip mansion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        AudioManager.instance.GetComponent<AudioSource>().Pause();
        AudioManager.instance.PlayMusic(mansion);
    }
}
