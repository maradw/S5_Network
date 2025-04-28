using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Reflection;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> _listing = new List<PlayerListing>();

    private RoomCanvases _roomCanvases;

    private void Awake()
    {
        GetCurrentRoomPlayers();
    }
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        _content.DestroyChildren();
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player player )
    {
        PlayerListing listing = Instantiate(_playerListing, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _listing.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
       AddPlayerListing(newPlayer);
        
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //base.OnPlayerLeftRoom(otherPlayer);

        int index = _listing.FindIndex(x => x._Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listing[index].gameObject);
            _listing.RemoveAt(index);
        }
    }

    /* //
     print("Recibí actualización de salas: " + roomList.Count + " salas.");

     foreach (RoomInfo info in roomList)
     {
         print("Sala detectada: " + info.Name);

     }

 }*/
}
