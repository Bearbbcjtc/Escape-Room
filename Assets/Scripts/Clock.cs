using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class Clock : MonoBehaviour
{
    private float timeRemaining = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient && timeRemaining > 0.0f)
        {
            float time = timeRemaining - Time.deltaTime;
            GetComponent<PhotonView>().RPC("SyncTime", RpcTarget.All, time);
        }
    }

    public float GetTime()
    {
        return timeRemaining;
    }

    public void SetTime(float time)
    {
        GetComponent<PhotonView>().RPC("SyncTime", RpcTarget.All, time);
    }

    [PunRPC]
    public void SyncTime(float time)
    {
        timeRemaining = time;
    }
}
