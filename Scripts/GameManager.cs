using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public GameObject[] enemys;
    public GameObject healbox; 
    
    public float startWait = 2f; //시작 대기시간 2초(1f = 1초)
    public float spwanWait = 0.1f; //스폰 대기시간
    public float healWait = 10f;// 10s
    public float healSpawn;// random timef
    //public float waveWait = 0.1f;
    
    public ScoreManager scm;    
    private GameObject gameOverPannel;
    private GameObject stagePannel;
    //private GameObject pausePannel;
    private UIEvent uiEvent;    

    public bool isGameover = false;
    public bool restart = false;
    //private bool isBackMusicStop = false;
    //private bool isPause = false;
    private bool isStart = false;

    public float time;//난이도 타이머
    //sound
    public AudioSource backMusic;
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;
    public AudioClip bgm1;
    public AudioClip bgm2;
    /*
    private bool isBlackSquare = true;
    public GameObject player;
    public GameObject playerPos;
    */
    void Awake()
    {
        Application.targetFrameRate = 60;//프레임 60고정
        stagePannel = GameObject.Find("Canvas").transform.Find("StageUI").gameObject;
        gameOverPannel = GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject;

        //ScoreManager scm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //UIEvent uiEvent = GetComponent<UIEvent>();

        RandomizeSfx(bgm1, bgm2);
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = UnityEngine.Random.Range(0, clips.Length);
        float randomPictch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        AudioManager.adm.StopMusic();
        backMusic.pitch = randomPictch;
        backMusic.clip = clips[randomIndex];
        backMusic.Play();
    }

    void Start()
    {
        /*if (isBlackSquare)
        {
            StartCoroutine("PlayerSpawn");
        }
        */
        time = 0;
        StartCoroutine("SpawnWaves");       
        //힐 스폰
        StartCoroutine("HealSpawn");

        isGameover = false;
        restart = false;
    }

    public void GameOver()//2
    {
        backMusic.Stop();
        isGameover = true;
        restart = true;
        //Debug.Log("isGameover = " + isGameover);
        
        Time.timeScale = 0f;//멈추고
        //Debug.Log("멈춤");
        scm.isEnd = true;
        //Debug.Log("isEnd = TRUE");
        scm.EndCountScore();
        //Debug.Log("EndCountScore run");
        gameOverPannel.SetActive(true);        
        stagePannel.SetActive(false);
        //Debug.Log("Ui???? " + isGameover);
    }
    
   /* IEnumerator PlayerSpawn()
    {
        yield return new WaitForSeconds(0f);
        Vector3 playerSpawnPos = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, 0f);
        Instantiate(player, playerSpawnPos, Quaternion.identity);
    }*/

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);//2초 후에     

        if(!isStart)
        {
            while (true) // 조건까지 반복
            {                
                for (int i = 0; i < 20; i++)
                {
                    GameObject enemy = enemys[Random.Range(0, 1)]; //0
                    Vector3 spawnPosition = new Vector3(Random.Range(-24f, 24f), 10.1f, 0f);
                    Quaternion spawnRoation = Quaternion.identity;
                    //생성
                    Instantiate(enemy, spawnPosition, spawnRoation);
                    //대기
                    yield return new WaitForSeconds(0.3f);//spawnWait
                }
                //yield return new WaitForSeconds(0.2f);                

                if (isGameover == true || time >= 50) //50end
                {
                    break;
                }
            }

            while (true) // 조건까지 반복
            {
                for (int i = 0; i < 20; i++)
                {
                    GameObject enemy = enemys[Random.Range(0, 1)]; //0
                    Vector3 spawnPosition = new Vector3(Random.Range(-24f, 24f), 10.1f, 0f);
                    Quaternion spawnRoation = Quaternion.identity;
                    //생성
                    Instantiate(enemy, spawnPosition, spawnRoation);
                    //대기
                    yield return new WaitForSeconds(0.2f);//spawnWait
                }
                //yield return new WaitForSeconds(0.2f);                

                if (isGameover == true || time >= 100) //100end
                {
                    break;
                }
            }

            while (true)
            {
                for (int i = 0; i < 25; i++)
                {
                    GameObject enemy = enemys[Random.Range(0, 2)];//01
                    Vector3 spawnPosition = new Vector3(Random.Range(-24f, 24f), 10.1f, 0f);
                    Quaternion spawnRoation = Quaternion.identity;
                    //생성
                    Instantiate(enemy, spawnPosition, spawnRoation);
                    //대기
                    yield return new WaitForSeconds(0.2f);
                }
                //yield return new WaitForSeconds(0.1f);

                if (isGameover == true || time >= 250)//251end
                {
                    break;
                }
            }

            while (true)
            {
                for (int i = 0; i < 30; i++)
                {
                    GameObject enemy = enemys[Random.Range(0, 3)];//012
                    Vector3 spawnPosition = new Vector3(Random.Range(-24f, 24f), 10.1f, 0f);
                    Quaternion spawnRoation = Quaternion.identity;
                    //생성
                    Instantiate(enemy, spawnPosition, spawnRoation);
                    //대기
                    yield return new WaitForSeconds(0.1f);
                }
                //yield return new WaitForSeconds(0.2f);

                if (isGameover == true || time >= 400)//401end
                {
                    break;
                }
            }

            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    GameObject enemy = enemys[Random.Range(0, 4)];//0123
                    Vector3 spawnPosition = new Vector3(Random.Range(-24f, 24f), 10.1f, 0f);
                    Quaternion spawnRoation = Quaternion.identity;
                    //생성
                    Instantiate(enemy, spawnPosition, spawnRoation);
                    //대기
                    yield return new WaitForSeconds(0.1f);
                }
                //yield return new WaitForSeconds(0.5f);

                if (isGameover == true)
                {
                    break;
                }
            }
        }        
    }

    IEnumerator HealSpawn()
    {
        yield return new WaitForSeconds(healWait); //10초 후에

        healSpawn = Random.Range(15f, 35f); // 20s~35s

        while (true)
        {
            GameObject heal = healbox;
            Vector3 healBoxPosition = new Vector3(Random.Range(-19f, 19f), 10.1f, 0f);//-16.8f-16.8f
            Instantiate(heal, healBoxPosition, Quaternion.identity);

            yield return new WaitForSeconds(healSpawn); //20s~40s after

            if (isGameover == true)
            {
                break;
            }
        }       
    }

    void Update()
    {
        time += Time.deltaTime * 10f;
        //재시작 키 'R'
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(3, LoadSceneMode.Single);
            }            
        }

        if (isGameover)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("over => main");
                gameOverPannel.SetActive(false);
                Time.timeScale = 1f;                
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                //isBackMusicStop = true;
                //RestartBakcMusic();
                AudioManager.adm.StartMusic();
                //Debug.Log("over => main sucess");
            }            
        }
    }
}
