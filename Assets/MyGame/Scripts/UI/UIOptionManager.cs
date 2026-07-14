using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("DangSon/UIOptionManager")]
public class UIOptionManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
   private void Start()
    {
        musicSlider.value = DataManager.DataMusic;
        sfxSlider.value = DataManager.DataSfx;
    } 
    // Update is called once per frame
    public void UpdateMusic(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
        DataManager.DataMusic = volume;
    }
    public void UpdateSfx(float volune)
    {
        AudioManager.Instance.SetSfxVolume(volune);
        DataManager.DataSfx = volune;
    }
}
