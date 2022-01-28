using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
}
