using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScriptTesting : MonoBehaviour
{
    public static MoveScriptTesting instance;

    public float Speeds; //Speeds of character
    [SerializeField] Transform target = null;
    private InventoryScriptUI inventoryUI;
    Vector3 targetPos;
    public bool isMoving = false;
    bool isPlayed = false;
    public bool isLeftClicked = false;
    public Animator animator; //Animation purpose
    bool FacingRight = false;

    //Event
    public delegate void PressLeftClickEvent(bool f);
    public PressLeftClickEvent OnPressLeftClick;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        inventoryUI = GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryScriptUI>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(Speeds));
        animator.speed = 1.5f;
        if (Input.GetMouseButtonDown(0))
        {
            isLeftClicked = true;
            if(inventoryUI.isOpen == false)
            {
                SetPosition();
            }
            else
            {
                Debug.Log("Inventory opened");
                return;
            }

            if(OnPressLeftClick != null)
            {
                OnPressLeftClick.Invoke(isLeftClicked);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            isLeftClicked = false;
        }
        if (isMoving == true)
        {
            Move();
        }
    }
    public void SetPosition()
    {
        targetPos = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        checkLeftOrRight(targetPos.x);
        target.position = targetPos;
        targetPos.z = transform.position.z;
        targetPos.y = transform.position.y;
        isMoving = true;
    }

    public void checkLeftOrRight(float x)
    {
        if(x >= this.gameObject.transform.position.x && !FacingRight)
        {
            //this.gameObject.transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            flip();
        }
        else if (x <= this.gameObject.transform.position.x && FacingRight)
        {
            //this.gameObject.transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            flip();
        }
    }

    private void flip()
    {
        FacingRight = !FacingRight;

        transform.Rotate(Vector3.up * 180);
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }

    public void SetFeeze()
    {
        targetPos = this.gameObject.transform.position;
        target.position = targetPos;
        targetPos.z = transform.position.z;
        targetPos.y = transform.position.y;
        isMoving = false;
        isPlayed = false;
    }

    public void StopMoving()
    {
        if(isMoving == true)
        {
            Speeds = 0f;
            SetFeeze();
            isMoving = false;
            isPlayed = false;
            FindObjectOfType<AudioManager>().Pause("Moving");
        }
        else
        {
            return;
        }
    }

    public void Move()
    {
        //transform.position = Quaternion.LookRotation(Vector3.foward, targetPos);
        Speeds = 13f;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Speeds * Time.deltaTime);
        if(isPlayed == false)
        {
            FindObjectOfType<AudioManager>().Play("Moving");
            isPlayed = true;
        }
        if (transform.position == targetPos)
        {
            isMoving = false;
            isPlayed = false;   
            Speeds = 0f;
            FindObjectOfType<AudioManager>().Pause("Moving");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemySoldier_1"))
        {
            SceneManager.LoadScene("MainMenu");
            FindObjectOfType<AudioManager>().Stop("BGM");
            FindObjectOfType<AudioManager>().Stop("Moving");
        }

    }


}
