using TMPro;
using UnityEngine;

public class DropDownBehaviour : MonoBehaviour
{
    //get GameController Reference


    public void CheckDropdownValue()
    {
        

        //decisions based on dropdown choice
        //saves exit condition value in playerprefs to be used in next scene
        switch (gameObject.GetComponent<TMP_Dropdown>().value)
        {
            case 0:
                PlayerPrefs.SetInt("gameWinCondition" , 0);
                break;

            case 1:
                PlayerPrefs.SetInt("gameWinCondition", 5);
                break;

            case 2:
                PlayerPrefs.SetInt("gameWinCondition", 10);
                break;

            case 3:
                PlayerPrefs.SetInt("gameWinCondition", 15);
                break;

            case 4:
                PlayerPrefs.SetInt("gameWinCondition", 20);
                break;

            case 5:
                PlayerPrefs.SetInt("gameWinCondition", 25);
                break;

        }
    }
}
