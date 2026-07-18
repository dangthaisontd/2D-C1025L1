using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/Bullet")]
public class Bullet : MonoBehaviour
{
    [Header("Property")]
    public int damageValue = 10;
    [Header("Audio")]
    public AudioClip audioClip;
    [Header("Timer Destroy Bullet")]
    public float timerLifle = 2.0f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke(nameof(Hide), timerLifle);
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlayPlayerSfxMusic(audioClip);
        Instantiate(GameManager.Instance.sfxPrefabs, transform.position, Quaternion.identity);
        if(collision.CompareTag("Enemy"))
        {
            ICanTakeDamage takeDamage = collision.GetComponent<ICanTakeDamage>();
            if (takeDamage!=null)
            {
                takeDamage.TakeDamage(damageValue, Vector2.zero, gameObject);
            }
        }   
        gameObject.SetActive(false);
    }
}
