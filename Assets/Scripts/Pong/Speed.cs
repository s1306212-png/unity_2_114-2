using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button speedmode;
    void Start()
    {
        speedmode.onClick.AddListener(() => {
            SceneManager.LoadScene("Pong");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
