using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("DangSon/UIManager")]
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private TextMeshProUGUI textCoin;
    [SerializeField] private TextMeshProUGUI textHealth;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject gameOverUI;
    private Player player;
    private void Start()
    {
        UpdateCoin(DataManager.DataCoin);
        Invoke("Delay", 0.5f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null )
        UpdateHealth(player.maxHealth);
    }
    void Delay()
    {
        GameEvent.eventHealth.AddListener(UpdateHealth);
        GameEvent.eventCoinsComplted.AddListener(UpdateCoin);
        GameEvent.eventUpdateUI.AddListener(UpdateUI);
    }
    // Update is called once per frame
    public void UpdateCoin(int coin)
    {
        textCoin.text = "Coin: "+ coin.ToString();
    }
    public void UpdateHealth(int health)
    {
        sliderHealth.value = health;
        textHealth.text = "Health: "+health.ToString();
    }
    public void UpdateUI()
    {
        mainUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
