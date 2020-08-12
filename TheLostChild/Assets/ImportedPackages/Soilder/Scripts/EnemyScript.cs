using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    float moveSpeed = 0;

    Rigidbody2D rb2d;

    bool isFacingLeft = false;

    public float moveSpeedPatrol = 1f;
    public Transform leftWayPoint;
    public Transform rightWayPoint;
    bool movingRight = true;
    public bool patrolState = true;
    public bool pointingState = true;
    public bool caughtState = false;

    public Animator animator; //Animation purpose
    bool FacingRight = false;

    public GameObject enemyParent;
    public GameObject enemyParent2;

    bool isRepeat = true;
    bool activeThis = true;

    

    public GameObject []Walls;

    void Awake()
    {
        if (enemyParent != null)
        {
            enemyParent.SetActive(false);
            enemyParent2.SetActive(false);
        }
    }

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        animator.keepAnimatorControllerStateOnDisable = true;
        //Patrol 
        //leftWayPoint = GameObject.Find("LeftWayPoint").GetComponent<Transform>();
        //rightWayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsPatrol", patrolState);
        animator.SetBool("isPointing", pointingState);
        animator.SetBool("isCaught", caughtState);


        if (patrolState)
        {
            moveSpeed = 1;
            rb2d.velocity = new Vector2(moveSpeed, 0);
            //Left & Right way points
            if (transform.position.x > rightWayPoint.position.x)
                movingRight = false;
            if (transform.position.x < leftWayPoint.position.x)
                movingRight = true;

            if (movingRight)
                moveRight();
            else
                moveLeft();

            Walls[0].SetActive(true);
            Walls[1].SetActive(true);
            Walls[2].SetActive(true);
            Walls[3].SetActive(true);
            Walls[4].SetActive(true);

            agroRange = 5;
        }
        else if (!patrolState && pointingState)
        {
            if (isRepeat)
            {
                if (activeThis)
                {
                    moveSpeed = 0;
                    rb2d.velocity = new Vector2(moveSpeed, 0);
                    StartCoroutine(EnemyPointFinger());
                    isRepeat = false;
                }

            }
        }
    }


    private void FixedUpdate()
    {
        if (CanSeePlayer(agroRange))
        {
            patrolState = false;
            //ChasePlayer();
        }
        else
        {
            //StopChasingPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0;
            rb2d.velocity = new Vector2(moveSpeed, 0);
            patrolState = false;
            pointingState = false;
            caughtState = true;
            activeThis = false;
            isRepeat = false;

            //MoveScriptTesting.instance.StopMoving();
            //MoveScriptTesting.instance.isStop = true;

            player.GetComponent<MoveScriptTesting>().StopMoving();
            player.GetComponent<MoveScriptTesting>().isStop = true;

            Debug.Log(player.GetComponent<MoveScriptTesting>().isStop);

            //GameObject.Find("Player").GetComponent<MoveScriptTesting>().enabled = false;
            //StartCoroutine(GameOver());
            StartCoroutine(DefaultState());
            Debug.Log("DEAD");


        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DeadScene");
        AudioManager.instance.Stop("BGM");
        AudioManager.instance.Stop("Moving");
    }

    IEnumerator DefaultState()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("ABLE");
        patrolState = true;
        pointingState = true;
        caughtState = false;
    }

    public bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Character"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Walls[0].SetActive(false);
                Walls[1].SetActive(false);
                Walls[2].SetActive(false);
                Walls[3].SetActive(false);
                Walls[4].SetActive(false);
                agroRange = 13;
                //moveSpeed = 2;
                Debug.DrawLine(castPoint.position, hit.point, Color.red);
                val = true;
                activeThis = true;
                patrolState = false;
                
            }
            /*else
            {
                //moveSpeed = 1;
                Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
                val = false;
                patrolState = true;
            }*/



        }
        else
        {
            isRepeat = true;
            if (activeThis)
            {
                activeThis = false;
                StartCoroutine(delayPatrol());
                //patrolState = true;
                Debug.DrawLine(castPoint.position, endPos, Color.blue);
            }
            Debug.DrawLine(castPoint.position, endPos, Color.blue);

        }

        return val;
    }

    IEnumerator delayPatrol()
    {
        yield return new WaitForSeconds(2f);
        patrolState = true;
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

    IEnumerator EnemyPointFinger()
    {
        //Put animation here!
        yield return new WaitForSeconds(1.4f);

        moveSpeed = 2;
        //rb2d.velocity = new Vector2(moveSpeed, 0);
        //Left & Right way points
        if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
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