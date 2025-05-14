using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCollisionDetector : MonoBehaviour
{
    private BallController ballControllerScript;    //reference BallController script
    private GameController gameControllerScript;    //reference GameController script
    private ScoreController scoreControllerScript;  //reference ScoreController script
    
    
    void Start()
    {
        //find required scripts
        ballControllerScript = GameObject.Find("BallManager").GetComponent<BallController>();
        gameControllerScript = GameObject.Find("GameManager").GetComponent<GameController>();
        scoreControllerScript = GameObject.Find("ScoreManager").GetComponent<ScoreController>();
    }

    //runs when ball collides with paddle
    private void OnCollisionEnter2D(Collision2D paddle)
    {
        //runs only if ball collides with paddle
        if(paddle.collider.tag=="paddle")
        {
            //play bounce audio
            //transform.Find used to find child object
            GameObject.Find("Audios").transform.Find("ballBounce").GetComponent<AudioSource>().Play();

            //adds speed/force to ball
            ballControllerScript.AddForceWhenBallPaddleCollide();

            //changes direction of ball based on where it hit the paddle
            //function takes position of ball this script is attached to and the other collider
            ballControllerScript.ChangeBallDirectionOnPaddleCollide(transform.position, paddle.collider.transform.position);
        }
    }

    //runs when ball enters deathzone
    private void OnTriggerEnter2D(Collider2D deathZone)
    {
        //runs only if ball collides with deathzone
        if (deathZone.tag == "deathzone")
        {
            //play death audio
            GameObject.Find("Audios").transform.Find("ballDeath").GetComponent<AudioSource>().Play();

            //kill ball, spawn another ball
            gameControllerScript.BallSpawnOrRespawn();

            if(deathZone.name == "DeathzoneR")
            {
                //if ball dies on right, point awarded to p1
                scoreControllerScript.UpdateScore(1);

            }
            else if(deathZone.name == "DeathzoneL")
            {
                //if ball dies on left, point awarded to p2
                scoreControllerScript.UpdateScore(2);
            }


        }
    }
}
