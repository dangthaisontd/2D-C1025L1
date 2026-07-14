using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("DangSon/ButtonBackManager")]
public class ButtonBackManager : MonoBehaviour
{
    public GameObject[] active;
    public GameObject[] unActive;
    private Button backButton;
    // Start is called before the first frame update
    void Start()
    {
       backButton= GetComponent<Button>();
       backButton.onClick.AddListener(OnClickButtonBack);
    }

    private void OnClickButtonBack()
    {
        AudioManager.Instance.PlayOnClick();
        foreach (var item in active)
        {
            item.SetActive(true);
        }
        foreach (var item in unActive)
        {
            item.SetActive(false);
        }
    }
}
