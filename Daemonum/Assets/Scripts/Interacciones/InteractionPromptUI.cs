using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private Text _promptText;
    private GameObject player;
    
    public bool IsDisplayed = false;

    private void Start()
    {
        _uiPanel.SetActive(false);
    }

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }
    public void Open()
    {
        _uiPanel.SetActive(true);
        player = GameObject.Find("Player");
        player.GetComponent<Movimiento>().canMove = false;
        IsDisplayed = true;
    }
    public void Close()
    {        
        _uiPanel.SetActive(false);
        player = GameObject.Find("Player");
        player.GetComponent<Movimiento>().canMove = true;
        IsDisplayed = false;
    }
}
