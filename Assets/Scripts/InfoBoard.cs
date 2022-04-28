using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

using TMPro;

public class InfoBoard : MonoBehaviour
{
    public TMP_Text boardText;
    private string boardInfo = "";

    // Start is called before the first frame update
    void Start()
    {
        boardInfo = boardText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo(string info)
    {
        boardInfo += info;
        GetComponent<PhotonView>().RPC("SyncInfo", RpcTarget.All);
    }

    [PunRPC]
    public void SyncInfo()
    {
        GetComponent<TMP_Text>().text = boardInfo;
    }
}
