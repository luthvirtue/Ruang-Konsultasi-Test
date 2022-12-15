using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;
using System.Linq;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;

public class LauncherScript : MonoBehaviourPunCallbacks
{
    public PhotonView[] photonPlayer;

    //VR variable
    public Transform XROriginTransform;

    //Position Lock
    public Vector3 spawnPosition;
    public LockAvatarPosition lockAvatarPosition;

    void Start()
    {
        //try to connect
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //connected to PUN
        Debug.Log("Connected to Master");
    }

    public void JoinRoomButton()
    {
        //Joining single room
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        //Set player name)
        SetPlayer();
        SetAllPlayersName();
    }

    public void SetPlayer()
    {
        //spawn player with random model
        int randomPlayer = Random.Range(0, photonPlayer.Length);
        GameObject playerAvatar = PhotonNetwork.Instantiate(photonPlayer[randomPlayer].name, spawnPosition, Quaternion.identity);

        //set player name
        string playerName = "Player" + PhotonNetwork.CurrentRoom.PlayerCount;
        PhotonNetwork.NickName = playerName;
        playerAvatar.name = PhotonNetwork.NickName;

        //set player into vr
        playerAvatar.transform.parent = XROriginTransform;
        playerAvatar.transform.localPosition = spawnPosition;

        //lockAvatarPositon;
        lockAvatarPosition.target = playerAvatar;
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