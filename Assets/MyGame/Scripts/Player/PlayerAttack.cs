using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[AddComponentMenu("DangSon/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    public float radiusAttack = 2f;
    public Transform pointAtack;
    public float attackRate=0.2f;
    public float nextAttack = 0;
    public float timeDelay = 0.2f;
    public LayerMask enemyLayer;
    public int  damagetoGive = 10;
    private Animator anim;
    private int isAttackAnimationId;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
        isAttackAnimationId = Animator.StringToHash("IsAttack");
    }

    // Update is called once per frame
    void Update()
    {
       if(IsAttackThisFrame())
        {
            if (GetKeyR())
            {
                anim.SetTrigger(isAttackAnimationId);
            }
        }
    }
    private bool IsAttackThisFrame()
    {
        var kb = Keyboard.current;
        if(kb == null) return false;
        if(kb.rKey.wasPressedThisFrame)
        {
            return true;
        }
        var gp = Gamepad.current;
        if(gp == null) return false;
        if(gp.buttonWest.wasPressedThisFrame)
        {
            return true;
        }
        return false;
    }   
    private bool GetKeyR()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            StartCoroutine(Attack());
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(timeDelay);
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(pointAtack.position, radiusAttack,enemyLayer);
        foreach (var enemy in hitEnemy)
        {
            var canTakeDmage = enemy.GetComponent<ICanTakeDamage>();
            if(canTakeDmage != null)
            {
                canTakeDmage.TakeDamage(damagetoGive, Vector2.down, gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (pointAtack != null)
        {
        Gizmos.DrawWireSphere(pointAtack.position, radiusAttack);
        }
    }
}
