﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EscMenu_m : NetworkBehaviour
{

    public GameObject EscapePanel;
    public SpaceshipControls_m Controls;
    private bool isEscape = false;

    void Start()
    {
        isEscape = false;
    }

    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown("escape"))
        {
            isEscape = !isEscape;
            EscapePanel.SetActive(isEscape);
            Controls.isInMenu = isEscape;

        }
    }
}