using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    public MoveScriptTesting playerScript;
    public TransferPlayer tpPlayer;

    public bool stopMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(stopMoving);
        if(stopMoving == true)
        {
            playerScript.StopMoving();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(OffDelay());
    }

    public void onLoading(TransferPlayer tp)
    {
        this.gameObject.SetActive(true);
        tpPlayer = tp;
        stopMoving = true;
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

}
