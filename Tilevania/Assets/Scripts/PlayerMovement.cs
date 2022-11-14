using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpStrength = 5f;
    [SerializeField] LayerMask climbLayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] CircleCollider2D groundCollider;
    [SerializeField] CapsuleCollider2D capsuleCollider;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Vector2 moveInput;
    bool isClimbing;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Run();
        Climb();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        var isMoving = Mathf.Abs(playerVelocity.x) > Mathf.Epsilon;
        if (isMoving)
            transform.localScale = new Vector3(Mathf.Sign(playerVelocity.x),1,1);
        anim.SetBool("isRunning", isMoving);
        rb.velocity = playerVelocity;
    }

    void Climb()
    {
        if (!capsuleCollider.IsTouchingLayers(climbLayer)) 
        {
            if (rb.velocity.y < 0)
                rb.gravityScale += Time.deltaTime;
            else rb.gravityScale = 2;
            anim.SetBool("isClimbing", false);
            return;
        }
        rb.gravityScale = 0;
        anim.SetBool("isClimbing", true);
        rb.velocity = new Vector2(rb.velocity.x, moveInput.y * moveSpeed);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log($"{moveInput}");
    }

    void OnJump(InputValue value)
    {
        if (!groundCollider.IsTouchingLayers(groundLayer) || isClimbing)
            return;
        rb.velocity += new Vector2(0f, jumpStrength);
        // rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    // void OnTriggerEnter2D(Collider2D trigger)
    // {
    //     if (trigger.gameObject.layer == 7)
    //     {
    //         rb.gravityScale = 0;
    //         isClimbing = true;
    //         anim.SetBool("isClimbing", true);
    //     }
    // }

    // void OnTriggerExit2D(Collider2D trigger)
    // {
    //     Debug.Log($"Exited trigger {trigger.gameObject.name}");
    //     if (trigger.gameObject.layer == 7)
    //     {
    //         isClimbing = false;
    //         anim.SetBool("isClimbing", false);
    //     }
    // }
}
