using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private int availableHealth;
    private void Update()
    {
        availableHealth = gameObject.GetComponent<PlayerController>().Health;
        if(availableHealth < 1)
        {
            gameObject.GetComponent<PlayerController>().ReloadLevel();
        }
    }
}
