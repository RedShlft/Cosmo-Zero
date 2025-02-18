﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutoMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Disp;
    public Image HealthBar;
    public Image HealthFill;
    // Use this for initialization
    void Start()
    {
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Panel.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Panel.gameObject.SetActive(true);
                Disp.gameObject.SetActive(false);
                HealthBar.gameObject.SetActive(false);
                HealthFill.gameObject.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                Panel.gameObject.SetActive(false);
                Disp.gameObject.SetActive(true);
                HealthBar.gameObject.SetActive(true);
                HealthFill.gameObject.SetActive(true);
            }
        }
    }
}
