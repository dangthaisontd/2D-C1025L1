using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/Player")]
public class Player : MonoBehaviour,ICanTakeDamage
{
    public int maxHealth = 100;
    public int currentHealth;
    [HideInInspector] public bool isDead = false;
    private Animator anim;
    private int IsDeadId;
    public float timerDelay = 1.5f;
    private PlayerController playerController;
    private PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();
        IsDeadId = Animator.StringToHash("IsDead");
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();
    }
    public void TakeDamage(int damage, Vector2 force, GameObject instigator)
    {
        if (isDead) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DeadPlayer();
        }
        UpdateHealth();
    }
    void DeadPlayer()
    {
        isDead = true;
        Debug.Log("Player Dead");
        anim.SetTrigger(IsDeadId);
        // StartCoroutine(UpdateUI());
        playerAttack.enabled = false;
        playerController.enabled = false;
        Invoke("UpdateUI", timerDelay);
    }
    void UpdateHealth()
    {
        // UIManager.Instance.UpdateHealth(currentHealth);
        GameEvent.eventHealth?.Invoke(currentHealth);
    }
   /* IEnumerator UpdateUI()
    {
      yield return new WaitForSeconds(timerDelay);
        UIManager.Instance.UpdateUI();
    }
   */
    void UpdateUI()
    {
        // UIManager.Instance.UpdateUI();
        GameEvent.eventUpdateUI?.Invoke();
    }
}
