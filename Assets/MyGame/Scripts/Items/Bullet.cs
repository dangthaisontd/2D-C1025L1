using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/Bullet")]
public class Bullet : MonoBehaviour
{
    [Header("Property")]
    public GameObject fxPrefabs;
    public int damageValue = 10;
    [Header("Audio")]
    public AudioClip audioClip;
    [Header("Timer Destroy Bullet")]
    public float timerDestroy = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timerDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlayPlayerSfxMusic(audioClip);
        Instantiate(fxPrefabs, transform.position, Quaternion.identity);
        if(collision.CompareTag("Enemy"))
        {
            ICanTakeDamage takeDamage = collision.GetComponent<ICanTakeDamage>();
            if (takeDamage!=null)
            {
                takeDamage.TakeDamage(damageValue, Vector2.zero, gameObject);
            }
        }   
        Destroy(gameObject);
    }
}
