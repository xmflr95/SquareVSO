using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float score;    
    public float endScore;
    public float recentScore;
    float time;
    public bool isEnd = false;
    private float bestScorePoint;

void Awake()
    {
        bestScorePoint = PlayerPrefs.GetFloat("BestScore");

        score = 0;

        EndCountScore();
    }

    void Update()
    {
        //기본 < 100        
        time = 5f;
        score += Time.deltaTime * time;
        //scoreLabel.text = string.Format("SCROE {0:N0}", score);

        if (score >= 100 && score < 200)
        {
            time = 8f;
            score += Time.deltaTime * time;
            //scoreLabel.text = string.Format("SCROE {0:N0}", score);
        }
        if (score >= 200 && score < 500)
        {
            time = 18f;
            score += Time.deltaTime * time;
            //scoreLabel.text = string.Format("SCROE {0:N0}", score);
        }
        else if(score >= 500 && score < 1000)
        {
            time = 30f;
            score += Time.deltaTime * time;
            //scoreLabel.text = string.Format("SCROE {0:N0}", score);
        }
        else if(score >= 1000 && score < 2000)
        {
            time = 40f;
            score += Time.deltaTime * time;
            //scoreLabel.text = string.Format("SCROE {0:N0}", score);
        }
        else if (score >= 2000 && score < 8000)
        {
            time = 50f;
            score += Time.deltaTime * time;
            //scoreLabel.text = string.Format("SCROE {0:N0}", score);
        }
        else if (score >= 8000)
        {
            time = 100f;
            score += Time.deltaTime * time;
            //scoreLabel.text = string.Format("SCROE {0:N0}", score);
        }
    }
    
    public void EndCountScore()
    {
        if (isEnd == true)
        {
            float end = Time.deltaTime * time * 0f;
            //Debug.Log("end = " + end);
            recentScore = score + end;
            //Debug.Log("recentscore = " + recentScore);
            endScore = recentScore;
            //Debug.Log("Endscore = " + endScore);
        }

        if (endScore > bestScorePoint)
        {
            bestScorePoint = endScore;
            PlayerPrefs.SetFloat("BestScore", bestScorePoint);
        }
    }    
}
