using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public GameObject[] enemys;
    //public AudioClip ac;

    public float startWait = 1f; //시작 대기시간 2초(1f = 1초)
    public float spwanWait = 1f; //스폰 대기시간
    public float waveWait = 2f; //스폰 대기시간

    void Start ()
    {
        StartCoroutine("SpawnWaves");        
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);//2초 후에     

        while (true) // 조건까지 반복
        {
            for (int i = 0; i < 100; i++)
            {
                GameObject enemy = enemys[Random.Range(0, enemys.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-1.5f, 20f), 14.5f, 0f);
                Quaternion spawnRoation = Quaternion.identity;
                //생성
                Instantiate(enemy, spawnPosition, spawnRoation);
                //대기
                yield return new WaitForSeconds(spwanWait);
            }
            yield return new WaitForSeconds(waveWait);            
        }
    }
}
