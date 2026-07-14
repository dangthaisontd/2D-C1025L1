using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
[AddComponentMenu("DangSon/Enemy")]
public class Enemy : MonoBehaviour,ICanTakeDamage
{
    [Header("Enemy Health")]
    public int maxHealth = 100;
    public int currentHealth;
    [Header("Attack")]
    public bool isDead = false;
    public float attackRate = 0.5f;
    public float nextAttack = 0;
    public int damagePlayer = 20;
    [Header("Enemy Fx")]
    public GameObject fxPrefabs;
    public Transform positionFx;
    public float timeDestroy = 5f;
    [Header("Audio Fx")]
    public AudioClip explusionClip;
    private Animator anim;
    private int IsDeadId;
    private EnemyAI enemyAI;
    private Rigidbody2D rb;
    private EnemyUI enemyUI;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();
        IsDeadId = Animator.StringToHash("IsDead");
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
        enemyUI = GetComponent<EnemyUI>();
    }
    public void TakeDamage(int damage, Vector2 force, GameObject instigator)
    {
        if (isDead) return;
        currentHealth -= damage;
        enemyUI.UpdateEnemyUI(currentHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
            DeadEnemy();
        }
    }
    private void DeadEnemy()
    {
        anim.SetTrigger(IsDeadId);
        enemyAI.enabled = false;
        rb.linearVelocity = Vector2.zero;
        Destroy(gameObject,timeDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("Player"))
        {
           if(collision.GetComponent<Player>().isDead == false)
            {
                Instantiate(fxPrefabs, positionFx.position, Quaternion.identity);
                AudioManager.Instance.PlayEnemySfxMusic(explusionClip);
                if (Time.time > nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    ICanTakeDamage damage = collision.GetComponent<ICanTakeDamage>();
                    if (damage != null)
                    {
                        damage.TakeDamage(damagePlayer, Vector2.right, gameObject);
                    }
                }
            }          
        }
    }
}
