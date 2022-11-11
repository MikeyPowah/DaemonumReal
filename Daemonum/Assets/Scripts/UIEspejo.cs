using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIEspejo : MonoBehaviour
{
    [SerializeField]
    private Text life, mana, attack, armor;
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
    }
}
