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
    private doorTouch door;

    void Start()
    {
        GameObject d = GameObject.Find("door_3_4");
        door = d.GetComponent<doorTouch>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine("playerChangeArea", 3f);
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

    public void puzzleEndRoom()
    {     
        if (door.playerTouch)
        {
            StartCoroutine("puzzleEnd");
        }   
    }

    void chaseToPlayer() //Chase to player
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public IEnumerator puzzleEnd()
    {
        yield return new WaitForSeconds(3);
        startChasing = false;
        this.gameObject.SetActive(false);
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
