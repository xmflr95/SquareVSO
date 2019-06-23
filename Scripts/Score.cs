using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //float score;
    //float time;
    //float scoreCount = ScoreManager.score;
    public ScoreManager scm;

    public Text scoreLabel;
    public Text lastScoreLabel;
    public Text highScoreLabel;    

    void Start ()
    {
        //ScoreManager scm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (scm.isEnd == true)
        {
            EndGameScore();
            //Debug.Log("lastscore register run");
            HighScore();
            //Debug.Log("highScore register run");
        }
    }
	
	void Update ()
    {        
        //scoreLabel.text = string.Format("SCROE {0:N0}", scm.score);
        scoreLabel.text = string.Format("SCORE {0:N0}", scm.score);               
    }

    void EndGameScore()
    {
        lastScoreLabel.text = string.Format("{0:N0}", scm.endScore);
        //Debug.Log("나까지 되면 될텐데? 포맷?");
    }

    void HighScore()
    {
        highScoreLabel.text = string.Format("{0:N0}", PlayerPrefs.GetFloat("BestScore"));
        //Debug.Log("Best = " + PlayerPrefs.GetFloat("BestScore"));
    }
}
