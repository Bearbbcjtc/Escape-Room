using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Transform leftHand;
    private Transform rightHand;
    private readonly float closeDist = 0.3f;
    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("OVRPlayerController");
        leftHand = player.transform.GetChild(1).GetChild(0).GetChild(4);
        rightHand = player.transform.GetChild(1).GetChild(0).GetChild(5);
    }

    // Update is called once per frame
    void Update()
    {
        float leftHandDist = Vector3.Distance(leftHand.position, transform.position);
        float rightHandDist = Vector3.Distance(rightHand.position, transform.position);
        if (leftHandDist < closeDist || rightHandDist < closeDist)
        {
            GetComponent<Outline>().enabled = true;
            isSelected = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
            isSelected = false;
        }

        if (isSelected)
        {
            if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
            {

            }
        }
    }
}
