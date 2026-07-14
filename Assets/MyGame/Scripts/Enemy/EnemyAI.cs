using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/EnemyAI")]
public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speedMove=2;
    private Transform target;
    public float minDistance = 0.2f;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private int IsIdleId;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = pointA;
        IsIdleId = Animator.StringToHash("IsIdle");
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleSpider"))
        {
            return;
        }
        Vector2 direction = (target.position-transform.position).normalized;
        if(Vector2.Distance(transform.position,target.position) < minDistance)
        {
            anim.SetTrigger(IsIdleId);
            target = target == pointB ? pointA : pointB;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        rb.linearVelocity = direction*speedMove;
    }
}
