using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ch56()
    {
        SceneManager.LoadScene(2);
    }

    public void ch5()
    {
        SceneManager.LoadScene(0);
    }

    public void ch6()
    {
        SceneManager.LoadScene(1);
    }
}
