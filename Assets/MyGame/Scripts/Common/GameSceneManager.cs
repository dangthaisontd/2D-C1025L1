using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[AddComponentMenu("DangSon/GameSceneManager")]
public class GameSceneManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject optionUI;
    public GameObject shopUI;
    public GameObject shopBuyUI;
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Main");
        AudioManager.Instance.PlayOnClick();
    }
    public void OnClickOption()
    {
        mainUI.SetActive(false);
        optionUI.SetActive(true);
        shopUI.SetActive(false);
        shopBuyUI.SetActive(false);
        AudioManager.Instance.PlayOnClick();
    }
    public void OnClickShop()
    {
        mainUI.SetActive(false);
        optionUI.SetActive(false);
        shopUI.SetActive(true);
        shopBuyUI.SetActive(false);
        AudioManager.Instance.PlayOnClick();
    }
    public void OnClickShopBuy()
    {
        mainUI.SetActive(false);
        optionUI.SetActive(false);
        shopUI.SetActive(false);
        shopBuyUI.SetActive(true);
        AudioManager.Instance.PlayOnClick();
    }
    public void OnClickExit()
    {
        AudioManager.Instance.PlayOnClick();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
           
#endif

    }
}
