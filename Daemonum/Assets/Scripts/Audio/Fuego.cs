using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    [SerializeField] private GameObject fuego;
    [SerializeField] AudioSource sonidoSource;
    private Animator fuegoA;
    public bool fuegoBool = true;
    public bool aguaBool = false;
    public bool rayoBool = false;
    private bool timerFuegoIsRunning = false;
    public float timeFuegoRemaining = 1;
    [SerializeField]
    private GameObject player;
    private StatsPlayer statsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        fuegoA = fuego.GetComponent<Animator>();
        statsPlayer = player.GetComponent<StatsPlayer>();
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
        if(Input.GetKeyDown(KeyCode.E) && !timerFuegoIsRunning && fuegoBool)
        {
            if(statsPlayer.elemental)
                desactivarFuego();
            else
                activarFuego();
        }

        if (Input.GetKeyDown(KeyCode.E) && !timerFuegoIsRunning && aguaBool)
        {
            if (statsPlayer.elemental)
                desactivarAgua();
            else
                activarAgua();
        }

        if (Input.GetKeyDown(KeyCode.E) && !timerFuegoIsRunning && rayoBool)
        {
            if (statsPlayer.elemental)
                desactivarRayo();
            else
                activarRayo();
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

        if(statsPlayer.currentMana <= 0)
        {
            if (fuegoBool)
                desactivarFuego();
            else if (aguaBool)
                desactivarAgua();
            else
                desactivarRayo();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !statsPlayer.elemental)
        {
            statsPlayer.UpdateElement(1);
            fuegoBool = true;
            aguaBool = false;
            rayoBool = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !statsPlayer.elemental)
        {
            statsPlayer.UpdateElement(2);
            aguaBool = true;
            fuegoBool = false;
            rayoBool = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !statsPlayer.elemental)
        {
            statsPlayer.UpdateElement(3);
            rayoBool = true;
            fuegoBool = false;
            aguaBool = false;
        }
    }

    private void activarFuego()
    {
        fuegoA.SetBool("Fuego", true);
        timerFuegoIsRunning = true;
        sonidoSource.mute = false;
        statsPlayer.elemental = true;
        statsPlayer.EnableElement();
    }

    private void desactivarFuego()
    {
        fuegoA.SetBool("Fuego", false);
        timerFuegoIsRunning = true;
        sonidoSource.mute = true;
        statsPlayer.elemental = false;
        statsPlayer.DisableElement();
    }

    private void activarAgua()
    {
        //fuegoA.SetBool("Fuego", true);
        timerFuegoIsRunning = true;
        sonidoSource.mute = false;
        statsPlayer.elemental = true;
        statsPlayer.EnableElement();
    }

    private void desactivarAgua()
    {
        //fuegoA.SetBool("Fuego", false);
        timerFuegoIsRunning = true;
        sonidoSource.mute = true;
        statsPlayer.elemental = false;
        statsPlayer.DisableElement();
    }

    private void activarRayo()
    {
        //fuegoA.SetBool("Fuego", true);
        timerFuegoIsRunning = true;
        sonidoSource.mute = false;
        statsPlayer.elemental = true;
        statsPlayer.EnableElement();
    }

    private void desactivarRayo()
    {
        //fuegoA.SetBool("Fuego", false);
        timerFuegoIsRunning = true;
        sonidoSource.mute = true;
        statsPlayer.elemental = false;
        statsPlayer.DisableElement();
    }
}
