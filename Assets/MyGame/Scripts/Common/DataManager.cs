using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/DataManager")]
public static class DataManager
{
    const int defaultValue = 0;
    const float defaultValueAudio = 1;
    public static int DataCoin
    {
        get => PlayerPrefs.GetInt(DataKey.KeyCoinId, defaultValue);
        set => PlayerPrefs.SetInt(DataKey.KeyCoinId, value);
    }
    public static float DataMusic
    {
        get=>PlayerPrefs.GetFloat(DataKey.KeyMusicId,defaultValueAudio);
        set=> PlayerPrefs.SetFloat(DataKey.KeyMusicId, value);
    }
    public static float DataSfx
    {
        get=>PlayerPrefs.GetFloat(DataKey.KeySfxId,defaultValueAudio);
        set=>PlayerPrefs.SetFloat(DataKey.KeySfxId, value);
    }
}
