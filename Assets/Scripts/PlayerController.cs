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
        float local_speed = animator.GetFloat("Speed");
        animator.SetFloat("Speed", Mathf.Abs(speed) + 1);
        Vector3 scale = transform.localScale;

        float vertical_data = Input.GetAxisRaw("Vertical"); // Out Put will Be -1 or +1
         
        //if (speed < 0)   // Left Side
        //{
        //    animator.SetBool("Crouch", false);
        //    scale.x = -1f * Mathf.Abs(scale.x);
        //    Debug.Log("Speed (" + speed + ") < 0 :  Scale X : " + scale.x);
        //}
        //else if (speed > 0)  // Right Side
        //{
        //    animator.SetBool("Crouch", false);
        //    scale.x = Mathf.Abs(scale.x);
        //    Debug.Log("Speed (" + speed + ") > 0 Scale X : " + scale.x);
        //}

        if (Input.GetKeyDown(KeyCode.LeftControl) || (Input.GetKeyDown(KeyCode.RightControl) )) //CTRL Control
        {
            //Debug.Log("Local Speed (" + local_speed + ") ");
            animator.SetFloat("Speed", 1.5f);
            animator.SetBool("Crouch", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            //Debug.Log("Local Speed (" + local_speed + ") ");
        }

        if (Input.GetKeyDown(KeyCode.F) ) //F = Walk Control
        {
            animator.SetFloat("Speed", 1.5f);
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.J)) //J = Jump Control
        {
            animator.SetFloat("Speed", 1.5f);
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", true);
        }

        if (speed > 0) //Right Side
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
        }
        if (speed < 0)  // Left Side
        {
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        if(vertical_data > 0)
        {
            animator.SetFloat("Speed", 1.5f);
            animator.SetBool("Jump", true);
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", false);
        }

        if (vertical_data < 0)
        {
            animator.SetFloat("Speed", 1.5f );
            animator.SetBool("Jump", false);
            animator.SetBool("Crouch", true);
            animator.SetBool("Walk", false);
        }


        transform.localScale = scale;
    }
}
