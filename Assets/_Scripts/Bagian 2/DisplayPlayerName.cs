using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class DisplayPlayerName : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public string playerName;
    private TextMeshProUGUI playerTMPro;

    void Start()
    {
        SetPlayerName();
    }

    private void Update()
    {
        SetPlayerName();
    }

    private void SetPlayerName()
    {
        //display player name based on parent GameObject name
        playerTMPro = GetComponent<TextMeshProUGUI>();
        playerName = player.name;
        playerTMPro.text = playerName;
    }
}
