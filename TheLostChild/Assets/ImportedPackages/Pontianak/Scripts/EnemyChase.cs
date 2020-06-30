using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed;
    private Transform target;
    bool startChasing = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        StartCoroutine("coRoutineTest", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(startChasing)
            chaseToPlayer();
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
}
