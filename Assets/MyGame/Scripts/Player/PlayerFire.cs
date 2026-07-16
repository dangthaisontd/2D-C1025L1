using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[AddComponentMenu("DangSon/PlayerFire")]
public class PlayerFire : MonoBehaviour
{
    [Header("Bullets")]
    public GameObject bulletPrefab;
    public Transform  bulletPosition;
    public float  bulletSpeed=30.0f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsAttackThisFrame())
        {
            Fire();
        }
    }
    private bool IsAttackThisFrame()
    {
        var kb = Keyboard.current;
        if (kb == null) return false;
        if (kb.fKey.wasPressedThisFrame)
        {
            return true;
        }
        var gp = Gamepad.current;
        if (gp == null) return false;
        if (gp.buttonEast.wasPressedThisFrame)
        {
            return true;
        }
        return false;
    }
    private void Fire()
    {
       GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position,Quaternion.identity);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if(playerController.FaceRight())
            {
                rb.linearVelocity = bulletPosition.right * bulletSpeed;
            }
            else
            {
                Vector2 scale = bullet.transform.localScale;
                scale.x *= -1;
                bullet.transform.localScale = scale;
                rb.linearVelocity = - bulletPosition.right * bulletSpeed;
            }
        }
    }
}
