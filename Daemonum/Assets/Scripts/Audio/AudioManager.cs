using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource sonidoSource;
    [SerializeField] List<AudioClip> listaEspada = new List<AudioClip>();
    [SerializeField] List<AudioClip> listaEnemigoDaño = new List<AudioClip>();
    [SerializeField] List<AudioClip> listaEnemigoAtaque = new List<AudioClip>();
    [SerializeField] List<AudioClip> listaSlimeAtaque = new List<AudioClip>();
    [SerializeField] AudioClip treeBossAttack;
    [SerializeField] AudioClip nextAudio;
    [SerializeField] AudioClip comprar;
    [SerializeField] AudioClip muerteEnemigo;


    void Awake()
    {
        if (instance == null)
		{
			instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
    }

    public void PlayMusic(AudioClip clip)
	{
        //Debug.Log("AEDRUIFGHAPISEDUFGBHA IOSYEFGO");
		sonidoSource.clip = clip;
        sonidoSource.GetComponent<AudioSource>().volume = 0.30f;
		sonidoSource.GetComponent<AudioSource>().Play();
	}

    public void PlayMusicBatalla(AudioClip clip)
	{
        //Debug.Log("AEDRUIFGHAPISEDUFGBHA IOSYEFGO");
		sonidoSource.clip = clip;
        sonidoSource.GetComponent<AudioSource>().volume = 0.10f;
		sonidoSource.GetComponent<AudioSource>().Play();
	}

    public void CambiarVolumen(float volumen)
    {
        Debug.Log("AEDRUIFGHAPISEDUFGBHA IOSYEFGO");
        sonidoSource.GetComponent<AudioSource>().volume = volumen;
    }

    public void EspadaSFX()
    {
        AudioClip clip = listaEspada[Random.Range(0,5)];

        sonidoSource.PlayOneShot(clip, 0.35f);
    }

    public void EnemigoDañadoSFX()
    {
        AudioClip clip = listaEnemigoDaño[Random.Range(0,4)];

        sonidoSource.PlayOneShot(clip, 0.70f);
    }
    public void EnemigoAtaqueSFX()
    {
        AudioClip clip = listaEnemigoAtaque[Random.Range(0,6)];

        sonidoSource.PlayOneShot(clip, 1.5f);
    }

    public void SlimeAtaqueSFX()
    {
        AudioClip clip = listaSlimeAtaque[Random.Range(0,2)];

        sonidoSource.PlayOneShot(clip, 1f);
    }

    public void TreeBossAttackSFX()
    {
        sonidoSource.PlayOneShot(treeBossAttack, 0.70f);
    }

    public void NextDialogoSFX()
    {
        sonidoSource.PlayOneShot(nextAudio, 2f);
    }

    public void ComprarCosaSFX()
    {
        sonidoSource.PlayOneShot(comprar, 1.5f);
    }

    public void MuerteEnemigoSFX()
    {
        sonidoSource.PlayOneShot(muerteEnemigo, 1f);
    }
}
