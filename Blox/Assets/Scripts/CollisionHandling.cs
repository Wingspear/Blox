﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandling : MonoBehaviour
{
    public GameManager gameManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blox"))
        {
            gameManager.EndGame();
        }
    }
}
