using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //WHen I am Pressing Left or Right or Joy Stick Key when Movement that called.
        float speed = Input.GetAxisRaw("Horizontal"); // Out Put will Be -1 or +1
        animator.SetFloat("Speed", Mathf.Abs(speed) + 1);
        Vector3 scale = transform.localScale;
       
        if ( speed < 0)   // Left Side
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            Debug.Log("Speed ("+ speed  + ") < 0 :  Scale X : " + scale.x);
        }
        else if (speed > 0)  // Right Side
        {
            scale.x = Mathf.Abs(scale.x);
            Debug.Log("Speed (" + speed + ") > 0 Scale X : " + scale.x);
        }

        transform.localScale = scale;
    }
}
