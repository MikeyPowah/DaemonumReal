using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pantallazo : MonoBehaviour
{

    [SerializeField] private GameObject  m_GotHitScreen;


    public void gotHurt()
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.5f;

        m_GotHitScreen.GetComponent<Image>().color = color;
    }

    private void OnTriggerEnter(Collider collider)
    {
        //gotHurt();
        if(collider.gameObject.tag == "Enemigo")
        {
            gotHurt();
        }
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
    }
    
}
