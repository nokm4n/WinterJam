using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class MenuControls : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene("Dungeon");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    //Debug.Log("Exit pressed!");
}
