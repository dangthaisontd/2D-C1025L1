using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }
    private void Fire()
    {
       GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position,Quaternion.identity);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if(playerController.FaceRight())
            {
                rb.velocity = bulletPosition.right * bulletSpeed;
            }
            else
            {
                Vector2 scale = bullet.transform.localScale;
                scale.x *= -1;
                bullet.transform.localScale = scale;
                rb.velocity = - bulletPosition.right * bulletSpeed;
            }
        }
    }
}
