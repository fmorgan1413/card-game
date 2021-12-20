using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
