using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //23.14
    [SerializeField]
    public Transform castPoint;

    [SerializeField]
    public Transform player;

    [SerializeField]
    float agroRange = 5;

    [SerializeField]
    float moveSpeed = 4;

    Rigidbody2D rb2d;

    bool isFacingLeft = false;

    public float moveSpeedPatrol = 3f;
    Transform leftWayPoint;
    Transform rightWayPoint;
    bool movingRight = true;
    public bool patrolState = true;

    public Animator animator; //Animation purpose
    bool FacingRight = false;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //Patrol 
        leftWayPoint = GameObject.Find("LeftWayPoint").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsPatrol", patrolState);



        if (patrolState)
        {
            moveSpeed = 2;
            //Left & Right way points
            if (transform.position.x > rightWayPoint.position.x)
                movingRight = false;
            if (transform.position.x < leftWayPoint.position.x)
                movingRight = true;

            if (movingRight)
                moveRight();
            else
                moveLeft();
        }
        
        



        //Extra (USEFUL DONT DELETE) Below

        /*//distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer: " + distToPlayer);

        if (distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }*/

    }

    private void FixedUpdate()
    {
        if (CanSeePlayer(agroRange))
        {
            patrolState = false;
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Character") );

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                moveSpeed = 6;
                Debug.DrawLine(castPoint.position, hit.point, Color.red);
                val = true;

            }
            else
            {
                moveSpeed = 4;
                Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
                val = false;
                patrolState = true;
            }

            

        }
        else
        {
            patrolState = true;
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }

        return val;
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1); // to make the enemy object turn around of 1(right)
            isFacingLeft = false;

        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1); // to make the enemy object turn around of -1(left)
            isFacingLeft = true;
        }
    }

    void StopChasingPlayer()
    {
        //rb2d.velocity = new Vector2(0, 0); // or  Vector2.zero;(without putting 'new') <- is the same
    }

    void moveRight()
    {
        //enemy is to the left side of the player, so move right
        rb2d.velocity = new Vector2(moveSpeed, 0);
        transform.localScale = new Vector2(-1, 1); // to make the enemy object turn around of 1(right)
        isFacingLeft = false;
    }

    void moveLeft()
    {
        //enemy is to the right side of the player, so move left
        rb2d.velocity = new Vector2(-moveSpeed, 0);
        transform.localScale = new Vector2(1, 1); // to make the enemy object turn around of -1(left)
        isFacingLeft = true;
    }
}
