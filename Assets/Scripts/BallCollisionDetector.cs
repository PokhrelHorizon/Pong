using UnityEngine;

public class BallCollisionDetector : MonoBehaviour
{
    private BallController ballControllerScript;    //reference ballControllerScript

    void Start()
    {
        ballControllerScript = GameObject.Find("BallManager").GetComponent<BallController>();
    }

    
    private void OnCollisionEnter2D(Collision2D paddle)
    {
        //runs only if ball collides with paddle
        if(paddle.collider.tag=="paddle")
        {
            //adds speed/force to ball
            ballControllerScript.AddForceWhenBallPaddleCollide();

            //changes direction of ball based on where it hit the paddle
            //function takes position of ball(this script is attached to
            ballControllerScript.ChangeBallDirectionOnPaddleCollide(transform.position, paddle.collider.transform.position);
        }
    }
}
