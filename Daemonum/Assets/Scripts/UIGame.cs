using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text coin;

    [SerializeField]
    private GameObject player;
    private StatsPlayer statsPlayer;
    void Start()
    {
        statsPlayer = player.GetComponent<StatsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = statsPlayer.coin.ToString();
    }
}
