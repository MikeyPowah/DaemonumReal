using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pantallazo : MonoBehaviour
{

    [SerializeField] private GameObject  m_GotHitScreen;
    [SerializeField]
    private GameObject player;
    private StatsPlayer statsPlayer;

    void Start()
    {
        statsPlayer = player.GetComponent<StatsPlayer>();
    }

    public void gotHurt(float dmg)
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.9f;

        m_GotHitScreen.GetComponent<Image>().color = color;
        Debug.Log(dmg);
        statsPlayer.UpdateHealth(-1);
    }

    private void Update()
    {
        if(m_GotHitScreen != null)
        {
            if(m_GotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.001f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }
        if(statsPlayer.currentLife <= 0)
        {
            Debug.Log("muelto");
        }
    }
    
}
