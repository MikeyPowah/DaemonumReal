using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay2 : MonoBehaviour
{
    public AudioClip musica;
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
        AudioManager.instance.PlayMusicBatalla(musica);
    }
}
