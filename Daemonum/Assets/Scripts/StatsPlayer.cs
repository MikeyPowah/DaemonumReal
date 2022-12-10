using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsPlayer : MonoBehaviour
{
    public int maxLife, maxMana, currentLife, currentMana, attack, coin, esence;
    public float elementalDamage;
    public bool elemental;
    float timeRemaining = 1;
    bool timerIsRunning = true;

    public int currentElement = 1;
    public int[] Elements;

    [SerializeField]
    private Image[] barraVida;
    [SerializeField]
    private Image[] barraMana;

    [SerializeField]
    private Image[] Vida;
    [SerializeField]
    private Image[] Mana;

    [SerializeField]
    private Image[] ElementsIMG;
    [SerializeField]
    private Image[] ActiveElementsIMG;

    [SerializeField] private GameObject m_GotHitScreen;
    // Start is called before the first frame update
    void Start()
    {
        //StatsManager.instance.getPlayer();
        currentLife = maxLife;
        currentMana = maxMana;
        UpdateMaxHealth(0);
        UpdateMaxMana(0);
        UpdateHealth(0);
        UpdateMana(0);
        for(int i = maxMana; i < Mana.Length; i++)
        {
            Mana[i].enabled = false;
        }
        for(int i = maxLife; i < Vida.Length; i++)
        {
            Vida[i].enabled = false;
        }

        for (int i = 0; i < Elements.Length; i++)
        {
            ActiveElementsIMG[i].enabled = false;
            if(Elements[i] == currentElement)
                ElementsIMG[i].enabled = true;
            else
                ElementsIMG[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerIsRunning = false;
                if (elemental)
                {
                    UpdateMana(-1);
                    timeRemaining = 1;
                }
                else
                {
                    UpdateMana(1);
                    timeRemaining = 2;
                }
                timerIsRunning = true;
            }
        }

        if (m_GotHitScreen != null)
        {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.001f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }
        if (currentLife <= 0)
        {
            omaeWaMouShindeiru();
        }
    }
    public void omaeWaMouShindeiru(){
        Debug.Log("muelto");
        SceneManager.LoadScene("Muerte");
        passStats();
    }
    public void passStats(){
        StatsManager.instance.setStats(maxLife, maxMana, attack, esence, elementalDamage);
    }
    public void passStatsWithCoins(){
        StatsManager.instance.setStatsWithCoins(maxLife, maxMana, attack, coin, esence, elementalDamage);
    }

    public void setStats(int maxL, int maxM, int a, int c, int e, float elem){
        maxLife = maxL;
        maxMana = maxM;
        attack = a;
        elementalDamage = elem;
        coin = c;
        esence = e;
    }
    
    public void UpdateMaxHealth(int health)
    {
        maxLife += health;
        
        for(int i = 0; i < barraVida.Length; i++)
        {
            if(5 + i == maxLife)
            {
                barraVida[i].enabled = true;
            }
            else
            {
                barraVida[i].enabled = false;
            }
        }
        UpdateHealth(health);
    }

    public void UpdateMaxMana(int mana)
    {
        maxMana += mana;
        
        for(int i = 0; i < barraMana.Length; i++)
        {
            if(5 + i == maxMana)
            {
                barraMana[i].enabled = true;
            }
            else
            {
                barraMana[i].enabled = false;
            }
        }
        UpdateMana(mana);
    }

    public void UpdateHealth(int health)
    {
        currentLife += health;
            //print("UpdateHealth " + health);

            for(int i = 0; i < maxLife; i++)
            {
                if(i < currentLife)
                {
                    Vida[i].enabled = true;
                }
                else
                {
                    Vida[i].enabled = false;
                }
            }
        /*if (currentLife + health <= maxLife && 0 <= currentLife + health)
        {
            
        }*/
    }

    public void UpdateMana(int mana)
    {
        //print("update mana " + mana);
        if (currentMana + mana <= maxMana && 0 <= currentMana + mana)
        {
            currentMana += mana;

            for(int i = 0; i < maxMana; i++)
            {
                if(i < currentMana)
                {
                    Mana[i].enabled = true;
                }
                else
                {
                    Mana[i].enabled = false;
                }
            }
        }
    }

    public void gotHurt(int dmg)
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.9f;

        m_GotHitScreen.GetComponent<Image>().color = color;
        Debug.Log(dmg);
        UpdateHealth(dmg);
    }

    public void UpdateElement(int num)
    {
        currentElement = num;

        for (int i = 0; i < Elements.Length; i++)
        {
            if (Elements[i] == currentElement)
                ElementsIMG[i].enabled = true;
            else
                ElementsIMG[i].enabled = false;
        }
    }

    public void EnableElement()
    {
        ElementsIMG[currentElement - 1].enabled = false;
        ActiveElementsIMG[currentElement - 1].enabled = true;
    }

    public void DisableElement()
    {
        ElementsIMG[currentElement - 1].enabled = true;
        ActiveElementsIMG[currentElement - 1].enabled = false;
    }
}
