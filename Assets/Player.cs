using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float moveInput;

    private bool canMove = true;   // 🔥 ตัวล็อกเดิน

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!canMove)
        {
            moveInput = 0;
            return;
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
            sprite.flipX = moveInput < 0;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // 🔥 ให้ HideSpot เรียกใช้
    public void SetMovement(bool state)
    {
        canMove = state;

        if (!state)
            rb.velocity = Vector2.zero;
    }
}