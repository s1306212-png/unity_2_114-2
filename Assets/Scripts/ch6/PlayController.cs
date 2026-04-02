using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //跳躍
        if (Input.GetKeyDown(KeyCode.Space)&&this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //角色速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //速度上限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //隨移動方向
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);


        if (transform.position.y < -10f)
        {
            Respawn();
        }
        void Respawn()
        {
            // 1. 回到重生點
            transform.position = new Vector3(-0.1f, -4.5f, 0f);

            // 2. 如果主角有掛載 Rigidbody (剛體)，需要把掉落的速度歸零
            // 否則重生後可能會因為殘留的重力加速度瞬間往下噴
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("終點");
        SceneManager.LoadScene("ch6_END");   
    } 
}
