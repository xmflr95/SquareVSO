using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvent : MonoBehaviour {

    private bool pauseOn = false;
    public bool isPause = false;
    private GameObject pausePannel;
    private GameObject gameOverPannel;
    //private GameObject mainPannel;

    public GameManager gm;

    public AudioClip click;
    public AudioClip stop;

    //private bool isBackMusicStop = false;

    void Start()
    {
        pausePannel = GameObject.Find("Canvas").transform.Find("PauseUI").gameObject;
        gameOverPannel = GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject;

        isPause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.backMusic.Pause();
            AudioManager.adm.PlaySingle(click);

            if (gm.isGameover == false)
            {
                //Debug.Log("stop->game");
                ActivePauseBtn();
            }
                  
        }

        if (isPause)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                AudioManager.adm.PlaySingle(click);
                Time.timeScale = 1f;
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
        }
        
    }

    public void ActivePauseBtn()
    {
        if (!pauseOn) //!pauseOn = true -> pauseOn = true
        {
            AudioManager.adm.PlaySingle(stop);
            isPause = true;
            Time.timeScale = 0f;
            pausePannel.SetActive(true);
            gm.backMusic.Pause();
        }        
        else
        {
            isPause = false;
            Time.timeScale = 1f;
            pausePannel.SetActive(false);
            gm.backMusic.Play();
        }

        pauseOn = !pauseOn; //불값 반전
    }

    public void RetryBtn()
    {
        //Debug.Log("게임 재시작");
        AudioManager.adm.PlaySingle(click);
        gameOverPannel.SetActive(false);
        Time.timeScale = 1f;        
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void MainBtn()
    {
        //Debug.Log("stop ->메인화면으로");
        AudioManager.adm.PlaySingle(click);
        gameOverPannel.SetActive(false);        
        Time.timeScale = 1f;        
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        AudioManager.adm.StartMusic();
    }
}
