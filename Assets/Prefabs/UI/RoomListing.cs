using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField] private TextMeshPro _text2;
    [SerializeField] private TextMesh _text3;
    [SerializeField] private TMP_Text _text4;
    public void SetRoomInfo(RoomInfo roomInfo) 
    {
        _text.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }
    
   
}
