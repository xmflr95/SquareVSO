using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTransitions : MonoBehaviour {

    public Animator transitionAnim;
    public string sceneName;

    //public MainEvent me;

    void Start ()
    {
        //MainEvent me = GameObject.Find("MainManager").GetComponent<MainEvent>();
	}
	
	void Update ()
    {
       
	}

    IEnumerator LoadLoading()
    {
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(1.5f);
    }
}
