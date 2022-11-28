using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    private Slider slider;
    
    void awake()
    {
        AudioManager.instance.GetComponent<AudioSource>();
        //AudioManager.instance.PlayMusic(mansion);
        AudioManager.instance.CambiarVolumen(0.50f);
    }

    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 20;
        
        slider.onValueChanged.AddListener(cambiarVolumen);
    }

    public void cambiarVolumen(float val)
    {
        AudioManager.instance.CambiarVolumen(val);
    }
}
