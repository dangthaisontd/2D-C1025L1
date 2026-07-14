using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[AddComponentMenu("DangSon/PlayerController")]
public class PlayerController : MonoBehaviour
{
    [Header("Public variable")]
    public LayerMask groundLayer;
    [Header("Private variable")]
    [SerializeField]  Transform groundCheck;
    [SerializeField]  float moveSpeed = 5.0f;
    [SerializeField] float jumForce = 5.0f;
    [SerializeField] float radius=0.5f;
    private Rigidbody2D rb;
    bool facingRight = true;
    private Animator anim;
    private int isWalkId;
    private int IsJumId;
    private float horizontalInput;
    private Vector2 velocityref = Vector2.zero;
    public float movementSmoonthing = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        isWalkId = Animator.StringToHash("IsWalk");
        IsJumId = Animator.StringToHash("IsJum");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = ReadHorizontalInput();
    }
    private void FixedUpdate()
    {
        MovePhysic();
    }

    private void MovePhysic()
    {
      Vector2 targetVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
      rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocityref, movementSmoonthing);
        if(horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }

    bool IsGround()
    {
       bool islocalGround = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
       return islocalGround;
    }
    IEnumerator Jum()
    {
        anim.SetTrigger(IsJumId);
        yield return new WaitForSeconds(0.3f);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumForce);
    }

    private float ReadHorizontalInput()
    {
        float keyboradDir = 0f;
        var kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.aKey.isPressed||kb.leftArrowKey.isPressed)
            {
                keyboradDir = -1f;
            }
            else if (kb.dKey.isPressed||kb.rightArrowKey.isPressed)
            {
                keyboradDir = 1f;
            }
        }
       var gp = Gamepad.current;
        if (gp != null)
        {
            if (gp.leftStick.ReadValue().x < -0.1f)
            {
                keyboradDir = -1f;
            }
            else if (gp.leftStick.ReadValue().x > 0.1f)
            {
                keyboradDir = 1f;
            }   
        }
        return keyboradDir;   
    }

    private void Flip()
    {
        facingRight=!facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public bool FaceRight()
    {
        return facingRight;
    }
}
