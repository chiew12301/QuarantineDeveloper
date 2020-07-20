using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontianakChase : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float betweenAreaDelay;
    bool startChasing = false;
    bool savedLocation = false;
    private Vector2 teleportLocation;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine("coRoutineTest", 2f);
        transform.position = new Vector2(target.position.x - 2, target.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (startChasing)
            chaseToPlayer();
        if (transform.position.y != target.transform.position.y)
        {
            startChasing = false;
            if (!savedLocation)
            {
                teleportLocation = target.transform.position;
                savedLocation = true;
            }
            StartCoroutine("playerChangeArea", betweenAreaDelay);
        }
    }

    void chaseToPlayer() //Chase to player
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    IEnumerator coRoutineTest(float waitTime)
    {
        //Debug.Log("Start"); //no delay
        yield return new WaitForSeconds(waitTime);
        startChasing = true;
        //Debug.Log("End");//delayed
    }

    IEnumerator playerChangeArea(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = teleportLocation;
        startChasing = true;
        savedLocation = false;
        StopAllCoroutines();
    }
}
