using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    public float baseSpeed = 5f;
    public float maxSpeed = Mathf.Infinity;
    public float currentSpeed { get; set; }

    // 【新增】球速增加的倍率，預設設為 1.01 (即每次增加 1% 速度)
    public float speedMultiplier = 1.01f;

    public void RunTaskA()
    {
        // 確保 Rigidbody2D 已被初始化
        if (rb == null)
        {
            Awake();
        }

        ResetPosition();
        AddStartingForce();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        // 確保剛體存在
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.zero;
        rb.position = Vector2.zero;
    }

    public void AddStartingForce()
    {
        // Flip a coin to determine if the ball starts left or right
        float x = Random.value < 0.5f ? -1f : 1f;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1f);

        // Apply the initial force and set the current speed
        Vector2 direction = new Vector2(x, y).normalized;
        rb.AddForce(direction * baseSpeed, ForceMode2D.Impulse);

        // 確保每次重新發球時，速度回歸基礎值
        currentSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        // Clamp the velocity of the ball to the max speed
        if (rb != null)
        {
            Vector2 direction = rb.velocity.normalized;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            rb.velocity = direction * currentSpeed;
        }
    }

    // 【新增】處理碰撞事件：當撞擊到球拍時增加球速
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 判斷撞到的是否為球拍。
        // 注意：請確保你在 Unity 編輯器中，將球拍遊戲物件的 Tag 設為 "Paddle"
        if (collision.gameObject.CompareTag("Paddle"))
        {
            currentSpeed *= speedMultiplier;
        }
    }
}