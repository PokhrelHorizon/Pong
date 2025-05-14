using UnityEngine;

public class StartOfGameParameters : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("gameWinCondition", 0); //set 0 at first
    }

    
}
