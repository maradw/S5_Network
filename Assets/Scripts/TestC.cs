using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

using Photon.Realtime;
public class TestC : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("Conect");
        PhotonNetwork.NickName =MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion; //
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Update()
    {
      //  Debug.Log("ola");
    }
    
    public override void OnConnectedToMaster()
    {
        print("coneccted");
        print(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconnected" + cause.ToString());
    }
    public override void OnJoinedLobby()
    {
        print("Entré al Lobby correctamente.");
    }
}
