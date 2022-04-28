using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class EscapeManager : MonoBehaviour
{
    public NetworkManager networkManager;

    private enum PlayerRole
    {
        Mother,
        GirlFriend,
        Detective,
        Classmate
    }

    private int localRole = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (localRole == -1)
        {
            if (networkManager.IsInARoom())
                localRole = PhotonNetwork.LocalPlayer.ActorNumber;
        }
        Debug.Log(localRole);
    }
}
