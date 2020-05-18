﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {

    }
    public void PlayGame()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1)); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

}
