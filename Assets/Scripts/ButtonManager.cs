using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Buttons(int sceneNumber)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }

    /*public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }*/
}
