using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public Player _Player { get; private set; }
    public void SetPlayerInfo(Player player)
    {
        _Player = player;
        _text.text = player.NickName;
    }


}
