using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    public int maxLife, maxMana, currentLife, currentMana, attack, armor, coin;

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
}
