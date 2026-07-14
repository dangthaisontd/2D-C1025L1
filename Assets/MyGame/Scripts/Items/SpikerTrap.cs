using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/SpikerTrap")]
public class SpikerTrap : MonoBehaviour
{
    [Header("Damage Health")]
    public int maxHealth = 100;
    [Header("Audio Damage")]
    public AudioClip audioClip;
    [Header("Fx")]
    public GameObject fxPrefabs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(fxPrefabs, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayPlayerSfxMusic(audioClip);
            ICanTakeDamage takeDamage = collision.GetComponent<ICanTakeDamage>();
            if (takeDamage != null)
            {
                takeDamage.TakeDamage(maxHealth, Vector2.zero, gameObject);
            }
        }
    }
}
