using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    private RoomInfo _player;
    public RoomInfo _roomInfo { get; private set; }
    
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }



}
