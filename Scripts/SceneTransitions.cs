using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//인트로 화면 이동 해주는 스크립트
public class SceneTransitions : MonoBehaviour {

    public Animator transitionAnim;
    //public string sceneName;

    public AudioClip click;
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//mouse = 0:left/1:right/2:wheel
        {
            AudioManager.adm.PlaySingle(click);
            StartCoroutine("LoadScene");           
        }
	}

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}
