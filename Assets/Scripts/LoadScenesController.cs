using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesController : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1 );
        //SceneManager.LoadSceneAsync("Level_1");
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadSceneAsync("Level_1");
    }
}
