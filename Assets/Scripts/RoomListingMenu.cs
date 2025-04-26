using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    /*[SerializeField]
    private GameObject roomInfoPanel;
    [SerializeField]
    private GameObject createRoomPanel;
    [SerializeField]
    private GameObject roomListPanel;*/
    // Start is called before the first frame update

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList)
        {
            RoomListing listing = Instantiate(_roomListing, _content);
            if (listing != null)
            {
                listing.SetRoomInfo(info);
            }
                
        }

          


        // base.OnRoomListUpdate(roomList);
        /*        //base.OnRoomListUpdate(roomList);
                foreach (Transform child in _content)
                {
                    Destroy(child.gameObject);
                }
                foreach (RoomInfo room in roomList)
                {
                    GameObject roomListing = Instantiate(_roomListing, _content);
                    RoomListing roomListingScript = roomListing.GetComponent<RoomListing>();
                    roomListingScript.SetRoomName(room.Name);
                    roomListingScript.SetPlayerCount(room.PlayerCount, room.MaxPlayers);
                    roomListingScript.SetRoomInfo(room);
                }
                //}

                base. OnRoomListUpdate(roomList);
        */

    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
