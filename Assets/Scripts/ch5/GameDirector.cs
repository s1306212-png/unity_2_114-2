using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("hp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecHp()
    {
        hp.GetComponent<Image>().fillAmount -= 0.1f;
        if((hp.GetComponent<Image>().fillAmount <= 0))
        {
            SceneManager.LoadScene("ch5_END");
        }
    }
}
