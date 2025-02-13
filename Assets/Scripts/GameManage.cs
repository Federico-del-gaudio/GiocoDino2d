using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    [Header("SpeedManagement")]
    [SerializeField] private int score;
    public AnimationCurve speedCurve;
    public float levelSpeed;

    [Space]
    [Header("UI")]
    public Text scoreText;
   [SerializeField] private GameObject GameOverButton;
    // Start is called before the first frame update
    void Start()
    {
        GameOverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      

        levelSpeed = speedCurve.Evaluate(Time.time);
        score = Mathf.FloorToInt(Time.time) ;
        scoreText.text = "SCORE:" + score.ToString() ;
    }

   public  float GetLevelSpeed()
    {
        return levelSpeed;
    }

    public void GameOverScreen()
    {
        GameOverButton.SetActive(true);
        Time.timeScale = 0 ;
       


    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        GameOverButton.SetActive(false);
        Time.timeScale = 1;
        score = 0 ;
    }
}
