using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public int maxLife, maxMana, currentLife, currentMana, attack, armor, coin;

    [SerializeField]
    private Image barraVida5, barraVida4, barraVida3, barraVida2, barraVida1, barraVida0;
    [SerializeField]
    private Image barraMana5, barraMana4, barraMana3, barraMana2, barraMana1, barraMana0;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int health)
    {
        currentLife += health;

        switch (currentLife)
        {
            case 0:
                barraVida5.enabled = false;
                barraVida4.enabled = false;
                barraVida3.enabled = false;
                barraVida2.enabled = false;
                barraVida1.enabled = false;
                barraVida0.enabled = true;
                break;
            case 1:
                barraVida5.enabled = false;
                barraVida4.enabled = false;
                barraVida3.enabled = false;
                barraVida2.enabled = false;
                barraVida0.enabled = false;
                barraVida1.enabled = true;
                break;
            case 2:
                barraVida5.enabled = false;
                barraVida4.enabled = false;
                barraVida3.enabled = false;
                barraVida1.enabled = false;
                barraVida0.enabled = false;
                barraVida2.enabled = true;
                break;
            case 3:
                barraVida5.enabled = false;
                barraVida4.enabled = false;
                barraVida2.enabled = false;
                barraVida1.enabled = false;
                barraVida0.enabled = false;
                barraVida3.enabled = true;
                break;
            case 4:
                barraVida5.enabled = false;
                barraVida3.enabled = false;
                barraVida2.enabled = false;
                barraVida1.enabled = false;
                barraVida0.enabled = false;
                barraVida4.enabled = true;
                break;
            case 5:
                barraVida4.enabled = false;
                barraVida3.enabled = false;
                barraVida2.enabled = false;
                barraVida1.enabled = false;
                barraVida0.enabled = false;
                barraVida5.enabled = true;
                break;
        }
    }

    public void UpdateMana(int mana)
    {
        //si queremos restar maná hay que pasar un número negativo por parámetro
        currentLife += mana;

        switch (currentLife)
        {
            case 0:
                barraMana5.enabled = false;
                barraMana4.enabled = false;
                barraMana3.enabled = false;
                barraMana2.enabled = false;
                barraMana1.enabled = false;
                barraMana0.enabled = true;
                break;
            case 1:
                barraMana5.enabled = false;
                barraMana4.enabled = false;
                barraMana3.enabled = false;
                barraMana2.enabled = false;
                barraMana0.enabled = false;
                barraMana1.enabled = true;
                break;
            case 2:
                barraMana5.enabled = false;
                barraMana4.enabled = false;
                barraMana3.enabled = false;
                barraMana1.enabled = false;
                barraMana0.enabled = false;
                barraMana2.enabled = true;
                break;
            case 3:
                barraMana5.enabled = false;
                barraMana4.enabled = false;
                barraMana2.enabled = false;
                barraMana1.enabled = false;
                barraMana0.enabled = false;
                barraMana3.enabled = true;
                break;
            case 4:
                barraMana5.enabled = false;
                barraMana3.enabled = false;
                barraMana2.enabled = false;
                barraMana1.enabled = false;
                barraMana0.enabled = false;
                barraMana4.enabled = true;
                break;
            case 5:
                barraMana4.enabled = false;
                barraMana3.enabled = false;
                barraMana2.enabled = false;
                barraMana1.enabled = false;
                barraMana0.enabled = false;
                barraMana5.enabled = true;
                break;
        }
    }
}
