using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float distancia;
    public Transform playerObj;
    private Transform enemy;
    protected NavMeshAgent enemyMesh;
    
    
    [SerializeField] int coins = 0;
    [SerializeField] int damage = 0;
    [SerializeField] float maxHealth = 10;
    [SerializeField] float health = 10;
    [SerializeField] Image healthbar;
    private bool timerIsRunning = false;
    private bool timerLoreyIsRunning = false;
    public bool isBoss = false;
    public float timeLoreyRemaining = 1;
    
    public float timeRemaining = 1;
    //[SerializeField] private NavMeshAgent enemyMesh;

    private float timerMuerte = 1f;
    private bool muerte = false;
    [SerializeField] private GameObject muerteGO;
    private Animator muerteA;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Espada" && !timerIsRunning)
        {
            timerIsRunning = true;
            enemyMesh.speed = 0;
            AudioManager.instance.EnemigoDañadoSFX();
            if (collider.gameObject.GetComponent<Espadote>().Fuego.fuegoBool
                && collider.gameObject.GetComponent<Espadote>().statsPlayer.elemental)
            {
                if (this.gameObject.CompareTag("Champi") || this.gameObject.CompareTag("TreeBoss"))
                    dañoEficaz(collider);
                else if (this.gameObject.CompareTag("SlimeAgua"))
                    dañoPocoEficaz(collider);
                else
                    dañoNeutro(collider);
            }
            else if(collider.gameObject.GetComponent<Espadote>().Fuego.aguaBool
                && collider.gameObject.GetComponent<Espadote>().statsPlayer.elemental)
            {
                if (this.gameObject.CompareTag("SlimeFuego"))
                    dañoEficaz(collider);
                else if (this.gameObject.CompareTag("Champi") || this.gameObject.CompareTag("TreeBoss"))
                    dañoPocoEficaz(collider);
                else
                    dañoNeutro(collider);
            }
            else if (collider.gameObject.GetComponent<Espadote>().Fuego.rayoBool
                && collider.gameObject.GetComponent<Espadote>().statsPlayer.elemental)
            {
                if (this.gameObject.CompareTag("SlimeAgua"))
                    dañoEficaz(collider);
                else if (this.gameObject.CompareTag("SlimeFuego"))
                    dañoPocoEficaz(collider);
                else
                    dañoNeutro(collider);
            }
            else
                dañoNeutro(collider);
        }

        //ataque a Lorey
        if(collider.gameObject.tag == "Lorey" && !timerLoreyIsRunning && !muerte)
        {
            timerLoreyIsRunning = true;
            Debug.Log("ATAQUE");
            enemyMesh.speed = 0;
            collider.gameObject.GetComponent<StatsPlayer>().gotHurt(-damage);
            if (this.gameObject.CompareTag("Champi"))
            {
                AudioManager.instance.EnemigoAtaqueSFX();
            } 
            else if (this.gameObject.CompareTag("SlimeAgua") || this.gameObject.CompareTag("SlimeFuego"))
            {
                AudioManager.instance.SlimeAtaqueSFX();
            } 
            else if (this.gameObject.CompareTag("TreeBoss"))
            {
                AudioManager.instance.TreeBossAttackSFX();
            }
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
        health = maxHealth;
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
                if(isBoss){
                    SceneManager.LoadScene("Game");
                    GameObject.Find("Player").GetComponent<StatsPlayer>().passStatsWithCoins();
                }else{
                    this.transform.parent.parent.GetComponent<EnemyGenerator>().isDead();
                }
                
                Destroy(gameObject);
            }
        }

    }

    public void gotHurt(float dmg)
    {
        health -= dmg;
        healthbar.fillAmount = health / maxHealth;
    }

    public void dañoEficaz(Collider collider)
    {
        gotHurt(collider.gameObject.GetComponent<Espadote>().statsPlayer.attack * collider.gameObject.GetComponent<Espadote>().statsPlayer.elementalDamage);
        Debug.Log("Eficaz con Daño:" + collider.gameObject.GetComponent<Espadote>().statsPlayer.attack * collider.gameObject.GetComponent<Espadote>().statsPlayer.elementalDamage);
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

    public void dañoNeutro(Collider collider)
    {
        gotHurt(collider.gameObject.GetComponent<Espadote>().statsPlayer.attack);
        Debug.Log("Neutro con Daño:" + collider.gameObject.GetComponent<Espadote>().statsPlayer.attack);
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

    public void dañoPocoEficaz(Collider collider)
    {
        gotHurt(collider.gameObject.GetComponent<Espadote>().statsPlayer.attack * (collider.gameObject.GetComponent<Espadote>().statsPlayer.elementalDamage - 1));
        Debug.Log("Poco Eficaz con daño: " + collider.gameObject.GetComponent<Espadote>().statsPlayer.attack * (collider.gameObject.GetComponent<Espadote>().statsPlayer.elementalDamage - 1));
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
