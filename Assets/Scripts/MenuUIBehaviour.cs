using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIBehaviour : MonoBehaviour
{
    private GameController gameControllerScript;


    //when resume button clicked
    public void OnResumeButtonClick()
    {
        gameControllerScript = GameObject.Find("GameManager").GetComponent<GameController>();
        gameControllerScript.GameResume();
    }

    //when exit button clicked, go to main menu
    public void OnExitButtonClick()
    {
        //unfreeze the scene before going to another scene.
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
    //used by button to go to game scene
    public void GoToGameOnButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    //used to restart game scene
    public void RestartOnButtonClick()
    {
        SceneManager.LoadScene("Game");

        //unfreeze the scene before going to another scene.
        Time.timeScale = 1f;
    }

    public void QuitGameOnButtonClick()
    {
        Application.Quit();
    }
    
}
