using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public int maxLife, maxMana, currentLife, currentMana, attack, armor, coin;
    public bool elemental;
    float timeRemaining = 1;
    bool timerIsRunning = true;

    [SerializeField]
    private Image barraVida5, barraVida6, barraVida7, barraVida8, barraVida9, barraVida10;
    [SerializeField]
    private Image barraMana5, barraMana6, barraMana7, barraMana8, barraMana9, barraMana10;

    [SerializeField]
    private Image Vida1, Vida2, Vida3, Vida4, Vida5, Vida6, Vida7, Vida8, Vida9, Vida10;
    [SerializeField]
    private Image Mana1, Mana2, Mana3, Mana4, Mana5, Mana6, Mana7, Mana8, Mana9, Mana10;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        currentMana = maxMana;
        UpdateMaxHealth(0);
        UpdateMaxMana(0);
        UpdateHealth(0);
        UpdateMana(0);
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
    }

    

    public void UpdateMaxHealth(int health)
    {
        maxLife += health;

        switch (maxLife)
        {
            case 5:
                barraVida5.enabled = true;
                barraVida6.enabled = false;
                barraVida7.enabled = false;
                barraVida8.enabled = false;
                barraVida9.enabled = false;
                barraVida10.enabled = false;
                break;
            case 6:
                barraVida5.enabled = false;
                barraVida6.enabled = true;
                barraVida7.enabled = false;
                barraVida8.enabled = false;
                barraVida9.enabled = false;
                barraVida10.enabled = false;
                break;
            case 7:
                barraVida5.enabled = false;
                barraVida6.enabled = false;
                barraVida7.enabled = true;
                barraVida8.enabled = false;
                barraVida9.enabled = false;
                barraVida10.enabled = false;
                break;
            case 8:
                barraVida5.enabled = false;
                barraVida6.enabled = false;
                barraVida7.enabled = false;
                barraVida8.enabled = true;
                barraVida9.enabled = false;
                barraVida10.enabled = false;
                break;
            case 9:
                barraVida5.enabled = false;
                barraVida6.enabled = false;
                barraVida7.enabled = false;
                barraVida8.enabled = false;
                barraVida9.enabled = true;
                barraVida10.enabled = false;
                break;
            case 10:
                barraVida5.enabled = false;
                barraVida6.enabled = false;
                barraVida7.enabled = false;
                barraVida8.enabled = false;
                barraVida9.enabled = false;
                barraVida10.enabled = true;
                break;
        }
    }

    public void UpdateMaxMana(int mana)
    {
        maxMana += mana;

        switch (maxMana)
        {
            case 5:
                barraMana5.enabled = true;
                barraMana6.enabled = false;
                barraMana7.enabled = false;
                barraMana8.enabled = false;
                barraMana9.enabled = false;
                barraMana10.enabled = false;
                break;
            case 6:
                barraMana5.enabled = false;
                barraMana6.enabled = true;
                barraMana7.enabled = false;
                barraMana8.enabled = false;
                barraMana9.enabled = false;
                barraMana10.enabled = false;
                break;
            case 7:
                barraMana5.enabled = false;
                barraMana6.enabled = false;
                barraMana7.enabled = true;
                barraMana8.enabled = false;
                barraMana9.enabled = false;
                barraMana10.enabled = false;
                break;
            case 8:
                barraMana5.enabled = false;
                barraMana6.enabled = false;
                barraMana7.enabled = false;
                barraMana8.enabled = true;
                barraMana9.enabled = false;
                barraMana10.enabled = false;
                break;
            case 9:
                barraMana5.enabled = false;
                barraMana6.enabled = false;
                barraMana7.enabled = false;
                barraMana8.enabled = false;
                barraMana9.enabled = true;
                barraMana10.enabled = false;
                break;
            case 10:
                barraMana5.enabled = false;
                barraMana6.enabled = false;
                barraMana7.enabled = false;
                barraMana8.enabled = false;
                barraMana9.enabled = false;
                barraMana10.enabled = true;
                break;
        }
    }

    public void UpdateHealth(int health)
    {
        if (currentLife + health <= maxLife && 0 <= currentLife + health)
        {
            currentLife += health;

            switch (currentLife)
            {
                case 0:
                    Vida1.enabled = false;
                    Vida2.enabled = false;
                    Vida3.enabled = false;
                    Vida4.enabled = false;
                    Vida5.enabled = false;
                    Vida6.enabled = false;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 1:
                    Vida1.enabled = true;
                    Vida2.enabled = false;
                    Vida3.enabled = false;
                    Vida4.enabled = false;
                    Vida5.enabled = false;
                    Vida6.enabled = false;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 2:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = false;
                    Vida4.enabled = false;
                    Vida5.enabled = false;
                    Vida6.enabled = false;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 3:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = false;
                    Vida5.enabled = false;
                    Vida6.enabled = false;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 4:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = false;
                    Vida6.enabled = false;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 5:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = true;
                    Vida6.enabled = false;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 6:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = true;
                    Vida6.enabled = true;
                    Vida7.enabled = false;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 7:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = true;
                    Vida6.enabled = true;
                    Vida7.enabled = true;
                    Vida8.enabled = false;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 8:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = true;
                    Vida6.enabled = true;
                    Vida7.enabled = true;
                    Vida8.enabled = true;
                    Vida9.enabled = false;
                    Vida10.enabled = false;
                    break;
                case 9:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = true;
                    Vida6.enabled = true;
                    Vida7.enabled = true;
                    Vida8.enabled = true;
                    Vida9.enabled = true;
                    Vida10.enabled = false;
                    break;
                case 10:
                    Vida1.enabled = true;
                    Vida2.enabled = true;
                    Vida3.enabled = true;
                    Vida4.enabled = true;
                    Vida5.enabled = true;
                    Vida6.enabled = true;
                    Vida7.enabled = true;
                    Vida8.enabled = true;
                    Vida9.enabled = true;
                    Vida10.enabled = true;
                    break;
            }
        }
    }

    public void UpdateMana(int mana)
    {
        print("update mana " + mana);
        if (currentMana + mana <= maxMana && 0 <= currentMana + mana)
        {
            currentMana += mana;

            switch (currentMana)
            {
                case 0:
                    Mana1.enabled = false;
                    Mana2.enabled = false;
                    Mana3.enabled = false;
                    Mana4.enabled = false;
                    Mana5.enabled = false;
                    Mana6.enabled = false;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 1:
                    Mana1.enabled = true;
                    Mana2.enabled = false;
                    Mana3.enabled = false;
                    Mana4.enabled = false;
                    Mana5.enabled = false;
                    Mana6.enabled = false;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 2:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = false;
                    Mana4.enabled = false;
                    Mana5.enabled = false;
                    Mana6.enabled = false;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 3:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = false;
                    Mana5.enabled = false;
                    Mana6.enabled = false;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 4:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = false;
                    Mana6.enabled = false;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 5:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = true;
                    Mana6.enabled = false;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 6:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = true;
                    Mana6.enabled = true;
                    Mana7.enabled = false;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 7:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = true;
                    Mana6.enabled = true;
                    Mana7.enabled = true;
                    Mana8.enabled = false;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 8:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = true;
                    Mana6.enabled = true;
                    Mana7.enabled = true;
                    Mana8.enabled = true;
                    Mana9.enabled = false;
                    Mana10.enabled = false;
                    break;
                case 9:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = true;
                    Mana6.enabled = true;
                    Mana7.enabled = true;
                    Mana8.enabled = true;
                    Mana9.enabled = true;
                    Mana10.enabled = false;
                    break;
                case 10:
                    Mana1.enabled = true;
                    Mana2.enabled = true;
                    Mana3.enabled = true;
                    Mana4.enabled = true;
                    Mana5.enabled = true;
                    Mana6.enabled = true;
                    Mana7.enabled = true;
                    Mana8.enabled = true;
                    Mana9.enabled = true;
                    Mana10.enabled = true;
                    break;
            }
        }
    }
}
