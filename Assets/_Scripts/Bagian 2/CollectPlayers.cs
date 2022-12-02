using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
To make sure every player changes their name based on PhotonNetwork.Nickname
***/

public class CollectPlayers : MonoBehaviourPunCallbacks
{
    void Update()
    {
        //set all players name on every frame
        SetAllPlayersName();
    }

    public void SetAllPlayersName()
    {
        //get all players GameObject
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerlist.Length; i++)
        {
            Debug.Log("P: " + playerlist[i].name);
            //change all player gameobject name
            playerlist[i].name = PhotonNetwork.PlayerList[i].NickName;
        }
    }
}
