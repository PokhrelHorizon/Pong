using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text p1ScoreText, p2ScoreText; //reference TMP objects
    public int p1Score, p2Score; //store and update score

    public void UpdateScore(int whichPlayer)
    {
        //check which player scored
        if (whichPlayer == 1)
        {
            p1Score++;

            //update score
            p1ScoreText.text = p1Score.ToString();
        }
        else if (whichPlayer == 2)
        {
            p2Score++;

            //update score
            p2ScoreText.text = p2Score.ToString();
        }

        
    }
}
