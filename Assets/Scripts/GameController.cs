using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //reference script
    private BallController ballControllerScript;
   

    [SerializeField] private float timeToMoveBall;

    [SerializeField] private GameObject pauseUI; //reference UI that activates when paused

    private bool gameIsPaused = false;  //stores whether game is true
    void Start()
    {
         
        ballControllerScript = GameObject.Find("BallManager").GetComponent<BallController>();   //get BallController Script
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
