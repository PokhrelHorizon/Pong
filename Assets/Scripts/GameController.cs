using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //reference script
    private BallController ballControllerScript;
    private ScoreController scoreControllerScript;

    [SerializeField] private float timeToMoveBall;

    [SerializeField] private GameObject pauseUI; //reference UI that activates when paused

    [SerializeField] private GameObject gameWinUI; //reference UI that activates when game is won

    [SerializeField] private TMP_Text WhichPlayerWonText;

    private bool gameIsPaused = false, gameisWon = false;  //stores whether game is true

    //to use when to award win to one player,gets from dropdownbehavior
    private int exitConditionValue;  
    void Start()
    {
        //get value from playerprefs
        exitConditionValue = PlayerPrefs.GetInt("gameWinCondition");

        ballControllerScript = GameObject.Find("BallManager").GetComponent<BallController>();   //get BallController Script
        scoreControllerScript = GameObject.Find("ScoreManager").GetComponent<ScoreController>();
        //spawn Ball
        BallSpawnOrRespawn();

    }


    private void Update()
    {
        //get Esc key to pause/resume game and activate/deactivate pause UI
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                GameResume();
            }
            else 
            {
                GamePause();
            }
        }

        //check if exit condition is satisfied, must not be zero(set as infinite config), greater or equal to max player score
        //gameisWon there as update tries to run this statement every time
        if((gameisWon == false) && (exitConditionValue !=0) && (scoreControllerScript.p1Score >= exitConditionValue || scoreControllerScript.p2Score >= exitConditionValue))
        {
            //activates UI
            gameWinUI.SetActive(true);

            //freeze time
            Time.timeScale = 0f;

            //change state
            gameisWon = true;

            //sets text as which player won
            if(scoreControllerScript.p1Score >= exitConditionValue)
            {
                WhichPlayerWonText.text = "Player 1 WINS";
            }
            else if (scoreControllerScript.p2Score >= exitConditionValue)
            {
                WhichPlayerWonText.text = "Player 2 WINS";
            }
        }
    }

    //Resume game
    public void GameResume()
    {
        //deactivates UI
        pauseUI.SetActive(false);

        //resumes in game time
        Time.timeScale = 1f;

        //set bool status
        gameIsPaused = false;
    }


    //Pause game
    public void GamePause()
    {
        //activates UI
        pauseUI.SetActive(true);

        //freezes in game time
        Time.timeScale = 0f;

        //set bool status
        gameIsPaused = true;
    }



    //used to spawn or respawnball
    public void BallSpawnOrRespawn()
    {
        //find and kill ball if one is there
        GameObject activeBall = GameObject.FindGameObjectWithTag("ball");
        if(activeBall != null)
        {
            Destroy(activeBall);
        }

        //Spawn Ball
        ballControllerScript.BallSpawn();

        //Delay ball moving and Move Ball
        StartCoroutine(BallWait(timeToMoveBall));
    }
    //Coroutine to use waitforseconds function
    IEnumerator BallWait(float timeToWait)
    {
        
        yield return new WaitForSeconds(timeToWait);

        //Move ball
        ballControllerScript.MoveBall();
    }

    
}
