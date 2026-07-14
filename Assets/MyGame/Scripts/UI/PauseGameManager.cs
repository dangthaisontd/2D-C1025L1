using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PauseGameManager")]
public class PauseGameManager : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelMain;
    public void OnPauseClick()
    {
            AudioManager.Instance.PlayOnClick();
            panelPause.SetActive(true);
            panelMain.SetActive(false);
            Time.timeScale = 0.0f;    
    }
    public void OnResumeClick()
    {
        AudioManager.Instance.PlayOnClick();
        Time.timeScale = 1.0f;
        panelMain.SetActive(true);
        panelPause.SetActive(false);
    }

}
