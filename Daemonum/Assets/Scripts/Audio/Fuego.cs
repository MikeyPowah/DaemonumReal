using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    [SerializeField] private GameObject fuego;
    [SerializeField] AudioSource sonidoSource;
    private Animator fuegoA;
    private bool fuegoBool = false;
    private bool timerFuegoIsRunning = false;
    public float timeFuegoRemaining = 1;
    // Start is called before the first frame update
    void Start()
    {
        fuegoA = fuego.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(mana <= 2)
        {
            fuegoA.SetBool("Fuego", false);
            fuegoBool = false;
            sonidoSource.mute = true;
        }*/
        if(Input.GetKeyDown(KeyCode.E) && !timerFuegoIsRunning)
        {
            if(fuegoBool)
            {
                fuegoA.SetBool("Fuego", false);
                fuegoBool = false;
                timerFuegoIsRunning = true;
                sonidoSource.mute = true;
            }
            else
            {
                fuegoA.SetBool("Fuego", true);
                fuegoBool = true;
                timerFuegoIsRunning = true;
                sonidoSource.mute = false;
            }
        } 
        
        if (timerFuegoIsRunning)
        {
            if (timeFuegoRemaining > 0)
            {
                timeFuegoRemaining -= Time.deltaTime;
            }
            else
            {
                timerFuegoIsRunning = false;
                timeFuegoRemaining = 1;
            }
        }
    }
}
