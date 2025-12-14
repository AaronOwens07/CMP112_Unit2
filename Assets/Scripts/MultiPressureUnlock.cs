using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MultiPressureUnlock : MonoBehaviour
{
    public List<PressurePlate> pressurePlates;
    public GameObject doorToUnlock;
    
    private bool doorUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!doorUnlocked)
        {
            CheckAllPlates();
        }
    }

    void CheckAllPlates()
    {
        foreach (PressurePlate plate in pressurePlates)
        {
            if (!plate.isPressed)
            {
                return; // Exit if any plate is not pressed
            }
        }
        UnlockDoor(); // All plates are pressed
    }

    void UnlockDoor()
    {
            doorToUnlock.SetActive(false);
            doorUnlocked = true;
    }
}
