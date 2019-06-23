using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainEvent : MonoBehaviour {

    public bool isStart = false;
    //private bool isClose = false;
    public Animator transitionAnim;
    public GameObject mainPanel;
    //public GameObject[] tips;
    //public string sceneName;
    //private bool isBackMusicStop = false;
    public AudioClip click;

    public GameObject[] characterPanel;
    private bool isSelectedPossiable = true;

    void Start()
    {
        mainPanel.SetActive(false);
        //isBackMusicStop = true;
        //RestartBakcMusic();
    }
    //캐릭터 선택
    public void IsSelectedFalse()
    {
        if (isSelectedPossiable)//현재 isSelectedP가 true이면 실행
        {
            isSelectedPossiable = false;
            //Debug.Log("false if안 " + isSelectedPossiable);
        }
    }
    
    public void IsSelectedTrue()
    {
        if (!isSelectedPossiable)//현재 isSelectedP가 false이면 실행
        {
            isSelectedPossiable = true;
            //Debug.Log("true if안 " + isSelectedPossiable);
        }
    }

    public void StartButton()
    {
        AudioManager.adm.PlaySingle(click);
        //isStart가 true여야 시작 (처음 isStart = false이므로 !isStart = true);
        if (!isStart && isSelectedPossiable)//isSelected는 캐릭터 가능 유무.
        {            
            StartCoroutine("LoadLoading");
        }
        // true -> false;

        /*if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StartButton();
            }            
        }*/
    }

    IEnumerator LoadLoading()
    {
        mainPanel.SetActive(true);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }    
}
