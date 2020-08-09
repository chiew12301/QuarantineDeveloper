﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastCollectorScript : MonoBehaviour
{
    public DisplayCollector dcScript;

    public Image JumpScareImage;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        JumpScareImage.gameObject.SetActive(false);
    }

    public void JumpScareActivate()
    {
        JumpScareImage.gameObject.SetActive(true);
        AudioManager.instance.Play("Jumpscare");
        StartCoroutine(TransferToStayTune());
;    }

    IEnumerator TransferToStayTune()
    {
        yield return new WaitForSeconds(2f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StayTuneScene");
    }

}