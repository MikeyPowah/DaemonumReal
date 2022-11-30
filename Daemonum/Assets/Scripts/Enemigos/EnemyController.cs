using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float distancia;
    public Transform playerObj;
    private Transform enemy;
    protected NavMeshAgent enemyMesh;
    
    [SerializeField] int coins = 0;
    [SerializeField] int damage = 0;
    [SerializeField] float health = 10;
    private bool timerIsRunning = false;
    private bool timerLoreyIsRunning = false;
    public float timeLoreyRemaining = 1;
    
    public float timeRemaining = 1;
    //[SerializeField] private NavMeshAgent enemyMesh;

    private float timerMuerte = 1f;
    private bool muerte = false;
    [SerializeField] private GameObject muerteGO;
    private Animator muerteA;

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Espada" && !timerIsRunning)
        {
            timerIsRunning = true;
            enemyMesh.speed = 0;
            AudioManager.instance.EnemigoDañadoSFX();
            if (collider.gameObject.GetComponent<Espadote>().statsPlayer.elemental)
            {
                gotHurt(collider.gameObject.GetComponent<Espadote>().statsPlayer.attack * collider.gameObject.GetComponent<Espadote>().statsPlayer.elementalDamage);
                if (health <= 0)
                {
                    GameObject.Find("Player").GetComponent<StatsPlayer>().coin += coins;
                    AudioManager.instance.MuerteEnemigoSFX();
                    muerteA.SetBool("Muerte", true);
                    Debug.Log("Enemigo muelto");
                    enemyMesh.speed = 0;
                    muerte = true;
                }
            }
            else { 
                gotHurt(collider.gameObject.GetComponent<Espadote>().statsPlayer.attack);
                if (health <= 0)
                {
                    GameObject.Find("Player").GetComponent<StatsPlayer>().coin += coins;
                    AudioManager.instance.MuerteEnemigoSFX();
                    muerteA.SetBool("Muerte", true);
                    Debug.Log("Enemigo muelto");
                    enemyMesh.speed = 0;
                    muerte = true;
                }
            }

        }
        if(collider.gameObject.tag == "Lorey" && !timerLoreyIsRunning && !muerte)
        {
            timerLoreyIsRunning = true;
            Debug.Log("ATAQUE");
            enemyMesh.speed = 0;
            if (this.gameObject.tag == "Champi")
            {
                collider.gameObject.GetComponent<StatsPlayer>().gotHurt(-damage);
                AudioManager.instance.EnemigoAtaqueSFX();
            } 
            else if (this.gameObject.tag == "Slime")
            {
                collider.gameObject.GetComponent<StatsPlayer>().gotHurt(-damage);
                AudioManager.instance.SlimeAtaqueSFX();
            } 
            else if (this.gameObject.tag == "TreeBoss")
            {
                collider.gameObject.GetComponent<StatsPlayer>().gotHurt(-damage);
                AudioManager.instance.TreeBossAttackSFX();
            }
            //LOREY DMG
            //statsPlayer.UpdateHealth(-1);
        }
    }
    /*
    private void OnTriggerStay(Collider col)
    {
        if (col == espada.GetComponent<Collider>() && !timerIsRunning && espada.GetComponent<Animator>().GetBool("Ataque"))
        {
            timerIsRunning = true;
            Debug.Log("Hola");
            enemyMesh.speed = 0;
            AudioManager.instance.EnemigoDañadoSFX();
            //ENEMY DMG
        }
        if(col == lorey.GetComponent<Collider>() && !timerLoreyIsRunning) 
        {
            timerLoreyIsRunning = true;
            Debug.Log("ATAQUE");
            enemyMesh.speed = 0;
            AudioManager.instance.EnemigoAtaqueSFX();
            //LOREY DMG
        }
    }
*/
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player").transform;
        enemyMesh = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
        muerteA = muerteGO.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(enemy.position,playerObj.position) <= distancia )
        {
            enemyMesh.SetDestination(playerObj.position);
        }
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                
            }
            else
            {
                timerIsRunning = false;
                timeRemaining = 1;
                enemyMesh.speed = 5;
            }
        }

        if (timerLoreyIsRunning)
        {
            if (timeLoreyRemaining > 0)
            {
                timeLoreyRemaining -= Time.deltaTime;
                
            }
            else
            {
                timerLoreyIsRunning = false;
                timeLoreyRemaining = 1;
                enemyMesh.speed = 5;
            }
        }

        if (muerte)
        {
            if (timerMuerte > 0)
            {
                timerMuerte -= Time.deltaTime;
                
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

    public void gotHurt(float dmg)
    {
        health -= dmg;
    }
}
