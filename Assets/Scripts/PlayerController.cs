using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    public GroundedCheck groundedCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal    = Input.GetAxisRaw("Horizontal"); // Out Put will Be -1 or +1
        float vertical      = Input.GetAxisRaw("Jump"); // Out Put will Be -1 or +1
        PlayMovementAnimation( horizontal, vertical );
        MoveCharacterControl( horizontal, vertical );
    }

    private void MoveCharacterControl( float horizontal , float vertical )
    {
        //Move Character Horizontally 
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Move Character Vertically
        if(vertical > 0)  
        {
            rb2d.AddForce(new Vector2( rb2d.velocity.x  , jump), ForceMode2D.Force);
        }
        
    }

    private void PlayMovementAnimation( float horizontal, float vertical )
    {
        //WHen I am Pressing Left or Right or Joy Stick Key when Movement that called.
        Vector3 scale = transform.localScale;
        animator.SetFloat("Speed", Mathf.Abs(horizontal) );

        if (horizontal > 0) //Right Side
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
        }
        else if (horizontal < 0)  // Left Side
        {
            animator.SetBool("Crouch", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        if (Input.GetKeyDown(KeyCode.LeftControl) || (Input.GetKeyDown(KeyCode.RightControl))) //CTRL Control
        {
            //Debug.Log("Local Speed (" + local_speed + ") ");
            animator.SetBool("Crouch", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            //Debug.Log("Local Speed (" + local_speed + ") ");
        }

        //if (Input.GetKeyDown(KeyCode.F)) //F = Walk Control
        //{
        //    animator.SetFloat("Speed", 1.5f);
        //    animator.SetBool("Crouch", false);
        //    animator.SetBool("Walk", true);
        //    animator.SetBool("Jump", false);
        //}

        if (vertical > 0 && isGrounded())
        {
            animator.SetBool("Jump", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }
        else
        {
            animator.SetBool("Jump", false);
             
        }
    }

    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundedCheck>().isGrounded;
    }
}
