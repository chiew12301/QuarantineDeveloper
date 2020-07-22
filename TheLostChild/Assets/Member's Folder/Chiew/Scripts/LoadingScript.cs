using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    public MoveScriptTesting playerScript;
    public TransferPlayer tpPlayer;

    public bool stopMoving = false;

    public Animator transition;
    private bool isTransfering = false;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isTransfering == true)
        {
            playerScript.isStop = isTransfering;
            playerScript.StopMoving();
        }
    }

    private void OnEnable()
    {
        //StartCoroutine(OffDelay());
        //StartCoroutine(TransferArea());
    }

    public void onLoading(TransferPlayer tp)
    {
        this.gameObject.SetActive(true);
        tpPlayer = tp;
        isTransfering = true;
        stopMoving = true;
        transition.SetTrigger("Start");
        StartCoroutine(TransferArea());
    }

    public void Transfer()
    {
        tpPlayer.AtFirstEnter();
    }

    IEnumerator OffDelay()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("set false");
        stopMoving = false;

        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        Transfer();
        yield return null;
    }

    IEnumerator TransferArea()
    {
        yield return new WaitForSeconds(1f);
        Transfer();
        isTransfering = false;
        stopMoving = false;
        playerScript.isStop = isTransfering;
        this.gameObject.SetActive(false);
    }

}
