using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private bool movingLeft = false;
    private float raylength = 10f;
    public Transform enemyTransform;
    public Transform endCheckTransform;
    public LayerMask layer;
     

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        EnemyPatrolling();
    }

    private void OnDrawGizmos()
    {
        Vector3 rayCastEnd = new Vector3( endCheckTransform.position.x, endCheckTransform.position.y - raylength, endCheckTransform.position.z );
        Gizmos.DrawLine(endCheckTransform.position, rayCastEnd);
    }

    private void EnemyPatrolling()
    {
        RaycastHit2D ground = Physics2D.Raycast(endCheckTransform.position, -endCheckTransform.up, raylength, layer);

        if (ground.collider == null )
        {
            Debug.Log(ground.collider);
            if (movingLeft == false)
            {
                Debug.Log("Moving Left = False");
                enemyTransform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = true;
            }
            else
            {
                Debug.Log("Moving Left = True");
                enemyTransform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();

        }
    }
}
