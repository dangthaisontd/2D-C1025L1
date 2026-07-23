using UnityEngine;
using TMPro;
public class InappUIManager : MonoBehaviour
{

   public TextMeshProUGUI coinText;
   public float timer=0.5f; 
    public void OnClick50Coins()
    {
        InAppManager.Instance.BuyProducId50();
    }
    public void OnClick100Coins()
    {
        InAppManager.Instance.BuyProducId100();
    }
    public void OnClick500Coins()
    {
        InAppManager.Instance.BuyProducId500();
    }
    public void OnClick1000Coins()
    {
        InAppManager.Instance.BuyProducId1000();
    }
    public void OnClick2000Coins()
    {
        InAppManager.Instance.BuyProducId2000();
    }
    public void OnClick5000Coins()
    {
        InAppManager.Instance.BuyProducId5000();
    }
    void Start()
    {
      StartCoroutine(UpdateCoinText());
    }
    System.Collections.IEnumerator UpdateCoinText()
    {
        while (true)
        {
            coinText.text = "Coins: " + DataManager.DataCoin.ToString();
            yield return new WaitForSeconds(timer);
        }
    }

}
