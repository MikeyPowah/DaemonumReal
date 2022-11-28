using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsLorey : MonoBehaviour
{

    [SerializeField] private GameObject  m_GotHitScreen;
    [SerializeField] private GameObject  espada;
    private float vida = 10;

    public void gotHurt(float dmg)
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.5f;

        m_GotHitScreen.GetComponent<Image>().color = color;
        Debug.Log(dmg);
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
        if(vida <= 0)
        {
            //canvas
            
        }
    }
    
}
