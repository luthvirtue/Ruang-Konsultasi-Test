using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;
using System.Linq;
using Photon.Realtime;

public class LauncherScript : MonoBehaviourPunCallbacks
{
    public Vector3 spawnPosition;
    public PhotonView[] photonPlayer;
    private int playerCount;

    void Start()
    {
        //try to connect
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //connected to PUN
        Debug.Log("Connected to Master");

        //Joining single room
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        //Set player name
        SetPlayerName();
        SetAllPlayersName();
    }

    public void SetPlayerName()
    {
        //spawn player with random model
        int randomPlayer = Random.Range(0, photonPlayer.Length);
        GameObject player = PhotonNetwork.Instantiate(photonPlayer[randomPlayer].name, spawnPosition, Quaternion.identity);

        string playerName = "Player" + PhotonNetwork.CurrentRoom.PlayerCount;
        PhotonNetwork.NickName = playerName;
        player.name = PhotonNetwork.NickName;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //set all players name when another player enter the room
        SetAllPlayersName();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //set all players name when another player left the room
        SetAllPlayersName();
    }

    public void SetAllPlayersName()
    {
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerlist.Length; i++)
        {
            Debug.Log("P: " + playerlist[i].name);
            playerlist[i].name = PhotonNetwork.PlayerList[i].NickName;
        }
    }
}