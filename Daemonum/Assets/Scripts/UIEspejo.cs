using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIEspejo : MonoBehaviour
{
    [SerializeField]
    private Text life, mana, attack, armor, coin, esence;
    [SerializeField]
    private GameObject player;
    private StatsPlayer statsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        statsPlayer = player.GetComponent<StatsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = statsPlayer.currentLife.ToString() + "/" + statsPlayer.maxLife.ToString();
        mana.text = statsPlayer.currentMana.ToString() + "/" + statsPlayer.maxMana.ToString();
        attack.text = statsPlayer.attack.ToString();
        armor.text = statsPlayer.armor.ToString();
        coin.text = statsPlayer.coin.ToString();
        esence.text = statsPlayer.esence.ToString();
    }

    public void BuyHealth()
    {
        if(statsPlayer.esence >= 20 && statsPlayer.maxLife < 10)
        {
            statsPlayer.UpdateMaxHealth(1);
            statsPlayer.esence -= 20;
        }
    }

    public void BuyMana()
    {
        if (statsPlayer.esence >= 20 && statsPlayer.maxMana < 10)
        {
            statsPlayer.UpdateMaxMana(1);
            statsPlayer.esence -= 20;
        }
    }

    public void BuyAttack()
    {
        if (statsPlayer.esence >= 20)
        {
            statsPlayer.attack++;
            statsPlayer.esence -= 20;
        }
    }

    public void BuyArmor()
    {
        if (statsPlayer.esence >= 20)
        {
            statsPlayer.armor++;
            statsPlayer.esence -= 20;
        }
    }

    public void BuyEsence()
    {
        if (statsPlayer.coin >= 5)
        {
            statsPlayer.esence++;
            statsPlayer.coin -= 5;
        }
    }
}
