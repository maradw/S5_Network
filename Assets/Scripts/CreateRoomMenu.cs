using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    /*[SerializeField]
    private GameObject createRoomPanel;
    [SerializeField]
    private GameObject roomListPanel;
    [SerializeField]
    private GameObject roomInfoPanel;
    [SerializeField]
    private GameObject roomListItemPrefab;
    [SerializeField]
    private Transform roomListContent;
    [SerializeField]
    private TextMeshProUGUI roomNameText;*/

    [SerializeField]
    private TextMeshProUGUI  roomName;

   
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
        PhotonNetwork.JoinOrCreateRoom("basic"+ roomName, options, TypedLobby.Default);
    }
    public override void OnCreatedRoom() 
    {
        //base.OnCreatedRoom();
        Debug.Log("Room Created " + roomName.text);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) 
    {
       // base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Room fail Creation" +  message);
    }
    
    
}
