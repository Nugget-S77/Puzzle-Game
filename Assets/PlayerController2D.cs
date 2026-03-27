using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float moveInput;

    private bool canMove = true; 

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
            // เพิ่มบรรทัดนี้: ถ้าเดินไม่ได้ ให้กลับไปท่า Idle ทันที
            animator.SetBool("is runing", false);
            return;
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            sprite.flipX = moveInput < 0;
            animator.SetBool("is runing", true); // เล่นท่าเดินเมื่อมีการกดปุ่ม
        }
        else
        {
            animator.SetBool("is runing", false); // กลับไปท่า Idle เมื่อไม่ได้กดปุ่ม
        }
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