using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    public string[] prize = { "凶", "大吉", "大凶", "小吉", "末吉", "中吉" };
    private float angle;
    public TextMeshProUGUI resultText;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        angle = 360f / prize.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.rotSpeed = 10;
        }
        transform.Rotate(0, 0, rotSpeed);
        rotSpeed *= 0.98f;
        float currentAngle = transform.eulerAngles.z;
        float adjustedAngle = (currentAngle + 90f) % 360f;
        int index = Mathf.FloorToInt(adjustedAngle / angle);
        //Debug.Log(transform.eulerAngles.z);
        string finalPrize = "";
        //if ()
        //{
        finalPrize = prize[(index - 1 + 6) % 6];
        //}
        if((index - 1 + 6) % 6==1 && rotSpeed<=0.5)
        {
            image.transform.position = new Vector3(0, 0, image.transform.position.z);
        }
        else
        {
            image.transform.position = new Vector3(100, 100, image.transform.position.z);

        }
        resultText.text = "結果:" + finalPrize;

    }
}