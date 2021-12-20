using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public void changetorules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void changetogame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void changetomain() 
    {
        SceneManager.LoadScene("Title");
    }
}
