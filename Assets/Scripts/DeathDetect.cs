﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetect : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().DeathDetect();
        }
            
    }
}
