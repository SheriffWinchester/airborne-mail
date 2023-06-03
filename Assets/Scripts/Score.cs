using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Score : MonoBehaviour
{
    public int score = 100;

    public GameObject winMenu;
    public GameObject loseMenu;
    public TextMeshProUGUI scoreWinText;
    public TextMeshProUGUI scoreLoseText;

    public GameObject pauseMenu;
    public GameObject tutorialMenu;
    bool gameIsPaused = false;

    void Start() 
    {
        scoreWinText = winMenu.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        scoreLoseText = loseMenu.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update() 
    {
        if(gameIsPaused == false)
        {
            Time.timeScale = 1;
        }
        if (score >= 1000)
        {   
            Time.timeScale = 0;
            winMenu.SetActive(true);
            scoreWinText.text = "Score " + score;

        }
        else if (score <= 0)
        {
            Time.timeScale = 0;
            loseMenu.SetActive(true);
            scoreLoseText.text = "Score 0";
            
        }
        // if(tutorialMenu.activeInHierarchy != true)
        // {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Time.timeScale = 1f;
                    pauseMenu.SetActive(false);
                    gameIsPaused = false;
                } else
                {
                    Time.timeScale = 0f;
                    pauseMenu.SetActive(true);
                    gameIsPaused = true;
                }
                if (tutorialMenu.activeInHierarchy == true)
                {
                    tutorialMenu.SetActive(false);
                }
            }
        //}
        
    }
}
