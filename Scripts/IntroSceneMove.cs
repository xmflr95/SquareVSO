using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneMove : MonoBehaviour {

    public Animator transitionAnim;
    //public string sceneName;

    void Start()
    {
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
