using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;
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
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconnected" + cause.ToString());
    }
}
