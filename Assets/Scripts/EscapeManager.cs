using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

public class EscapeManager : MonoBehaviour
{
    public NetworkManager networkManager;
    public Canvas canvas;
    private bool showRole = false;
    private bool showInfo = false;

    private const int ROLE_MOTHER = 1;
    private const int ROLE_DETECTIVE = 2;
    private const int ROLE_GIRLFRIEND = 3;
    private const int ROLE_CLASSMATE = 4;

    private int localRole = -1;

    private int currentItemId = -1;
    public InfoBoard board;

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

        if (showInfo || showRole)
            canvas.enabled = true;
        else
            canvas.enabled = false;

        if (showRole)
        {
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
            if (OVRInput.GetDown(OVRInput.Button.One))
                showRole = false;
        }

        if (showInfo)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                // Found
                string boardInfo = "\n";
                if (currentItemId == 1)
                    boardInfo += "Coffee maker";

                board.UpdateInfo(boardInfo);

                showInfo = false;
            }
            else if (localRole == ROLE_MOTHER && OVRInput.GetDown(OVRInput.Button.Three))
            {
                // Hide
                board.UpdateInfo("\nAn item has been hided by the murderer");

                showInfo = false;
            }
        }
    }

    public void ShowInfo(int itemId)
    {
        string info = "item";
        if (itemId == 1)
            info = "Coffee maker";

        if (localRole == ROLE_MOTHER)
            info += "\n\nYou can hide this item by pressing X";

        canvas.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = info;
        showInfo = true;
        currentItemId = itemId;
    }
}
