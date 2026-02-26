using UnityEngine;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    public string[] prizes = { "大吉", "中吉", "小吉", "大兇" };
    public Text res;
    public GameObject effect; // 拖入你的特效物件 (如煙火或閃光)
    float speed = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && speed < 0.1f)
        {
            speed = Random.Range(20f, 30f);
            if (effect) effect.SetActive(false); // 開始轉時關閉特效
        }

        transform.Rotate(0, 0, speed);
        speed *= 0.985f;

        if (speed > 0 && speed < 0.05f)
        {
            speed = 0;
            int i = Mathf.FloorToInt((360 - transform.eulerAngles.z) / (360f / prizes.Length)) % prizes.Length;
            res.text = prizes[i];

            // 判斷關鍵字：如果是大吉或大兇，開啟特效
            if (prizes[i].Contains("大") && effect) effect.SetActive(true);
        }
    }
}