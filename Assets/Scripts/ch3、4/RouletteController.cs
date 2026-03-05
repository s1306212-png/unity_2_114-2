using UnityEngine;
using TMPro;

public class Roulette : MonoBehaviour
{
    public Transform wheel;        // 輪盤
    public TextMeshProUGUI resultText; // 顯示結果

    public string[] options =
    {
        "兇", "大吉", "大兇", "小吉", "末吉", "中吉"
    };

    bool isSpinning = false;

    public void Spin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinWheel());
        }
    }

    System.Collections.IEnumerator SpinWheel()
    {
        isSpinning = true;

        float spinTime = 3f;
        float speed = Random.Range(720f, 1080f);

        float timer = 0;

        while (timer < spinTime)
        {
            wheel.Rotate(0, 0, speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        ShowResult();

        isSpinning = false;
    }

    void ShowResult()
    {
        float angle = wheel.eulerAngles.z;

        float sector = 360f / options.Length;

        int index = Mathf.FloorToInt(angle / sector);

        index = options.Length - 1 - index;

        resultText.text = options[index];
    }
}