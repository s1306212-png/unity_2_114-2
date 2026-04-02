using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tryagain : MonoBehaviour
{
    public Button tryagain;
    // Start is called before the first frame update
    void Start()
    {
        tryagain.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("ch5");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
