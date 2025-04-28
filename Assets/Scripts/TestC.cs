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
        PhotonNetwork.NickName = PlayerPrefs.GetString("PlayerName", "Player" + Random.Range(1000, 9999));

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
        if(!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
            print("funciona hasta aqui");
        }
        
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
