using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{


    [SerializeField]
    private TextMeshProUGUI  roomName;

    private RoomCanvases _roomCanvases;
    
    public void FirstInitialize(RoomCanvases canvas)
    {
        _roomCanvases = canvas;
    }
   
    public void OnClick_CreateRoom() 
    {
        if(!PhotonNetwork.IsConnected)
        {
            Debug.Log("Not Connected to Photon");
            return;
        }
        //CreateRoom
        //JoinOrCreateRoom
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("basic"+ roomName.text, options, TypedLobby.Default);
    }
    public override void OnCreatedRoom() 
    {
        //base.OnCreatedRoom();
        Debug.Log("Room Created " + roomName.text);
        _roomCanvases._CurrentRoom.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message) 
    {
       // base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Room fail Creation" +  message);
    }
    
    
}
