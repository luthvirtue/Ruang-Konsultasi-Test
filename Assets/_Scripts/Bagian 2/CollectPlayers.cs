using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayers : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        
    }

    void Update()
    {        
        //testing PhotonNetwork Nickname
        //GetPlayersName();

        //set all players name
        SetAllPlayersName();
    }

    public void SetAllPlayersName()
    {
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerlist.Length; i++)
        {
            Debug.Log("P: " + playerlist[i].name);
            //change all player gameobject name
            playerlist[i].name = PhotonNetwork.PlayerList[i].NickName;
        }
    }

    public void GetPlayersName()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Debug.Log("PL Nickname:" + PhotonNetwork.PlayerList[i].NickName);
        }
        for (int i = 0; i < PhotonNetwork.PlayerListOthers.Length; i++)
        {
            Debug.Log("Other Nickname:" + PhotonNetwork.PlayerListOthers[i].NickName);
        }
    }
}
