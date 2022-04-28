using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class EscapeManager : MonoBehaviour
{
    public NetworkManager networkManager;
    public Canvas canvas;
    private bool showRole = false;

    private const int ROLE_MOTHER = 1;
    private const int ROLE_DETECTIVE = 2;
    private const int ROLE_GIRLFRIEND = 3;
    private const int ROLE_CLASSMATE = 4;

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
            {
                localRole = PhotonNetwork.LocalPlayer.ActorNumber;
                showRole = true;
            }
        }

        if (showRole)
        {
            canvas.enabled = true;
            string text = "You are ";
            if (localRole == ROLE_MOTHER)
                text += "Mother";
            else if (localRole == ROLE_DETECTIVE)
                text += "detective";
            else if (localRole == ROLE_GIRLFRIEND)
                text += "girlfriend";
            else if (localRole == ROLE_CLASSMATE)
                text += "classmate";

            canvas.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = text;
            if (OVRInput.Get(OVRInput.Button.One))
                showRole = false;
        }
        else
            canvas.enabled = false;
    }
}
