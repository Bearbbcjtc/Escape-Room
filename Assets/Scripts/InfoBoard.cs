using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

using TMPro;

public class InfoBoard : MonoBehaviour
{
    private string boardInfo = "";

    // Start is called before the first frame update
    void Start()
    {
        boardInfo = GetComponent<TMP_Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo(string info)
    {
        boardInfo += info;
        GetComponent<PhotonView>().RPC("SyncInfo", RpcTarget.All, boardInfo);
    }

    [PunRPC]
    public void SyncInfo(string info)
    {
        GetComponent<TMP_Text>().text = info;
    }
}
