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
         
            ballControllerScript.AddForceWhenBallPaddleCollide();
        }
    }
}
