using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    BallController ballControllerScript;

    [SerializeField] private float timeToMoveBall;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
        ballControllerScript = GameObject.Find("BallManager").GetComponent<BallController>();   //get BallController Script


        //spawn Ball
        BallSpawnOrRespawn();
        
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
