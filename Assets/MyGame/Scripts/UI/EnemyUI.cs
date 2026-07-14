using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("DangSon/EnemyUI")]
public class EnemyUI : MonoBehaviour
{
    public Slider healthBar;
    // Update is called once per frame
    public void UpdateEnemyUI(int health)
    {
        healthBar.value = health;
    }
}
