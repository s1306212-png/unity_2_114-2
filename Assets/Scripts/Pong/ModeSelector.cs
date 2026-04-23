using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public enum GameMode
    {
        SinglePlayer = 0,
        TwoPlayer = 1,
        Endless = 2,
        CrazySpeed = 3
    }

    [Header("目前模式")]
    public GameMode currentMode;

    [Header("場景物件綁定")]
    public GameObject rightPaddle; // 右邊的球拍
    public GameObject rightWall;   // 右邊的牆壁 (無盡模式專用)
    // public Ball ball;           // 假設你有一個球的腳本，可以取消這行註解來控制球速

    // 2. 這個函式是要開放給 Unity 畫面上的 UI 按鈕呼叫的
    public void SelectMode(int modeIndex)
    {
        // 將按鈕傳進來的數字轉換成 Enum 模式
        currentMode = (GameMode)modeIndex;

        // 套用該模式的設定
        ApplyModeSettings();

        // 隱藏選單、開始遊戲的邏輯可以寫在這裡
        Debug.Log("遊戲開始！");
    }

    // 3. 根據選擇的模式，開啟/關閉對應的物件或功能
    private void ApplyModeSettings()
    {
        // 切換前，先全部重置回預設狀態，避免上一個模式的設定殘留
        ResetScene();

        switch (currentMode)
        {
            case GameMode.SinglePlayer:
                Debug.Log("載入：單人模式");
                rightPaddle.SetActive(true);
                // 這裡可以加入：rightPaddle.GetComponent<PaddleController>().EnableAI(true);
                break;

            case GameMode.TwoPlayer:
                Debug.Log("載入：雙人模式");
                rightPaddle.SetActive(true);
                // 這裡可以加入：rightPaddle.GetComponent<PaddleController>().EnableAI(false);
                break;

            case GameMode.Endless:
                Debug.Log("載入：隨機事件");
                rightPaddle.SetActive(false); // 關閉右邊球拍
                rightWall.SetActive(true);    // 開啟右邊牆壁讓他反彈
                break;

            case GameMode.CrazySpeed:
                Debug.Log("載入：極速模式");
                rightPaddle.SetActive(true);
                // 這裡可以加入：ball.SetSpeed(20f); // 讓球速變快
                break;
        }
    }

    // 負責把場景恢復原狀的函式
    private void ResetScene()
    {
        rightPaddle.SetActive(true);
        rightWall.SetActive(false);
        // ball.SetSpeed(10f); // 恢復預設球速
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
