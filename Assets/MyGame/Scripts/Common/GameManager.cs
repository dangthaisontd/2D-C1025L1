using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[AddComponentMenu("DangSon/GameManager")]
public class GameManager : MonoBehaviour
{
   private static GameManager instance;
   public static GameManager Instance
    {
        get => instance;
    }
    private void Awake()
    {
        if (instance != null) { 
            DestroyImmediate(gameObject);
            return;
        }
        instance = this; 
    }
    public int coin;
  
    // Start is called before the first frame update
    void Start()
    {
        this.coin = DataManager.DataCoin;
        //this.coin = PlayerPrefs.GetInt("Keycoin", 0);
        //UIManager.Instance.UpdateCoin(this.coin);
        if(GameEvent.eventHealth == null) GameEvent.eventHealth = new UnityEvent<int>();
        if(GameEvent.eventCoin ==null) GameEvent.eventCoin = new UnityEvent<int>();
        if (GameEvent.eventUpdateUI == null) GameEvent.eventUpdateUI = new UnityEvent();
        if(GameEvent.eventCoinsComplted ==null) GameEvent.eventCoinsComplted = new UnityEvent<int>();
        GameEvent.eventCoin.AddListener(UpdateCoin);
    }
    // Update is called once per frame
    public void UpdateCoin(int coin)
    {
        this.coin += coin;
       // UIManager.Instance.UpdateCoin(this.coin);
        DataManager.DataCoin=this.coin;
        GameEvent.eventCoinsComplted?.Invoke(this.coin);
        //PlayerPrefs.SetInt("Keycoin",this.coin);
       
    }
}
