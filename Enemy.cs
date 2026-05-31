using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float wallCheckDistance = 1f;

    private Vector3 startPos;
    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();

        // Ngăn tia cảm biến tự bắn trúng bản thân
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        // 1. KIỂM TRA QUÃNG ĐƯỜNG
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;

        if (movingRight && transform.position.x >= rightBound)
        {
            TurnAround();
        }
        else if (!movingRight && transform.position.x <= leftBound)
        {
            TurnAround();
        }
    }

    void FixedUpdate()
    {
        // 2. DI CHUYỂN VẬT LÝ
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        // 3. CẢM BIẾN DÒ TƯỜNG (Quét mặt đất)
        Vector2 rayDirection = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, wallCheckDistance);

        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            TurnAround();
        }
    }

    // 4. XỬ LÝ VA CHẠM CỨNG (GIẾT PLAYER & ĐỤNG TƯỜNG)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TH 1: Kẻ địch tông trúng Người chơi
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tự động tìm GameManager trong màn hình và gọi Game Over
            GameManager gm = FindAnyObjectByType<GameManager>();
            if (gm != null)
            {
                gm.GameOver();
            }
        }
        // TH 2: Kẻ địch tông trúng Tường cứng (Dự phòng cho tia cảm biến)
        else if (collision.gameObject.CompareTag("Ground"))
        {
            if (movingRight && collision.contacts[0].normal.x < 0)
            {
                TurnAround();
            }
            else if (!movingRight && collision.contacts[0].normal.x > 0)
            {
                TurnAround();
            }
        }
    }

    void TurnAround()
    {
        movingRight = !movingRight;
        Flip();
        startPos = transform.position;
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
