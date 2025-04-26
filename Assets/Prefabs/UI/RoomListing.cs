using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public RoomInfo _roomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo) 
    {
        _roomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }
    
   
}
