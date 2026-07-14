using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Move();
        if(IsGround() && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jum()); 
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

    void Move()
    {
        float horizontal =Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal*moveSpeed,rb.linearVelocity.y);
        if((horizontal>0&&!facingRight)||(horizontal<0&&facingRight))
        {
            Flip();
        }
        if(Math.Abs(horizontal)>0)
        {
            anim.SetBool(isWalkId, true);
        }
        else
        {
            anim.SetBool(isWalkId, false);
        }
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
