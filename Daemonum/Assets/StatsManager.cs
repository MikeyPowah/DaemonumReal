using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static StatsManager instance;
    public GameObject player;

    public int maxLife = 5, currentLife = 5, maxMana = 5, attack = 10, coin = 25, esence = 125;
    public float elementalDamage = 10;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        getPlayer();
        
    }
    public void setStats(int maxL, int currentLife, int maxM, int a, int e, float elem){
        maxLife = maxL;
        maxMana = maxM;
        attack = a;
        elementalDamage = elem;
        esence = e;
    }
    public void setStatsWithCoins(int maxL, int life, int maxM, int a, int c, int e, float elem){
        maxLife = maxL;
        currentLife = life;
        maxMana = maxM;
        attack = a;
        elementalDamage = elem;
        coin = c;
        esence = e;
    }
    public void getPlayer(){
        player = GameObject.Find("Player");
        if(player != null){

            player.GetComponent<StatsPlayer>().setStats(maxLife, currentLife, maxMana, attack, coin, esence, elementalDamage);

        }
    }
}
