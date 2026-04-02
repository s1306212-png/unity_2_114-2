using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text clock;
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    float jumpForce = 340.0f;
    GameObject player;
    public float a;
    float time = 0;
    void Start()
    {
        Application.targetFrameRate = 60;
        player = GameObject.Find("player");
        a = 0;
        InvokeRepeating(nameof(IncreaseClock), .01f, .01f);
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void IncreaseClock()
    {
        time += .01f;
        clock.text = $"存活時間: {System.Math.Round(time, 2)}";
    }

    // Update is called once per frame
    void Update()
    {
        //a++;
        //clock.text = (a / 60).ToString();
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
        }
        if((transform.position.x > 8.3))
        {
            player.transform.position = new Vector3(8.3f,transform.position.y,transform.position.z);
        }
        if((transform.position.x < -8.3))
        {
            player.transform.position = new Vector3(-8.3f, transform.position.y, transform.position.z);
        }
        a += 1;
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, -3.67f, 0f);
        }
        if (transform.position.y > 10f)
        {
            transform.position = new Vector3(0f, -3.67f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

    }
    public void LButton()
    {
        transform.Translate(-1, 0, 0);
    }
    public void RButton()
    {
        transform.Translate(1, 0, 0);
    }
}
