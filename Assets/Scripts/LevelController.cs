using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.GetComponent<PlayerController>() != null )
        {
            collision.gameObject.GetComponent<LoadScenesController>().LoadNextLevel();
            Debug.Log("Level Completed..Move to next level");
        } 
    }
}
