using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float paddleSpeed;
    [SerializeField] private GameObject PaddleLeft, PaddleRight;    //assign paddles in inspector

    private Rigidbody2D paddleLeftrb, paddleRightrb;   //store rigidbody of paddle

    private int moveDirection;      //assign movedirection in update to move body in fixed update

    void Start()
    {
        paddleLeftrb = PaddleLeft.GetComponent<Rigidbody2D>();
        paddleRightrb = PaddleRight.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Send Left Paddle Movement to function
        if(Input.GetKey(KeyCode.W))
        {
            MovePaddle(paddleLeftrb, 1);  //1: direction to +y
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MovePaddle(paddleLeftrb, -1);  // -1: direction to -y
        }


        //Send Right Paddle Movement to function
        if(Input.GetKey(KeyCode.UpArrow))
        {
            MovePaddle(paddleRightrb, 1); 
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            MovePaddle(paddleRightrb, -1); 
        }

    }

    //function to move paddle
    private void MovePaddle(Rigidbody2D paddlerb, float direction)
    {
        //pos.x keeps paddle in x pos
        paddlerb.MovePosition(new Vector2(paddlerb.position.x, paddlerb.position.y + direction * paddleSpeed ));
    }
    
}
