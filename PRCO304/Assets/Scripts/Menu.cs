﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject journalPanel;
    public GameObject inventoryPanel;
    public GameObject tooltipPanel;
    public GameObject entryPanel;
    private bool journalEnabled;
    private bool inventoryEnabled;
    void Start()
    {
        journalPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryEnabled == false)
        {
            tooltipPanel.SetActive(false);
        }
        if (journalEnabled == false)
        {
            entryPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (inventoryEnabled == true)
            {
                inventoryEnabled = false;
            }
            inventoryPanel.SetActive(false);
            journalEnabled = !journalEnabled;

            if (journalEnabled == true)
            {
                journalPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                journalPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (journalEnabled == true)
            {
                journalEnabled = false;
            }
            journalPanel.SetActive(false);
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)
            {
                inventoryPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                inventoryPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryEnabled == true)
            {
                inventoryPanel.SetActive(false);
                inventoryEnabled = !inventoryEnabled;
            }
            
            if (journalEnabled == true)
            {
                journalPanel.SetActive(false);
                journalEnabled = !journalEnabled;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}