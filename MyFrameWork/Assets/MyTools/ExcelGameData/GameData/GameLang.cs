﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameLang 
{
    public int Id;
    public string cn;
    public string en;
    private static Dictionary<int, GameLang> dictionary = new Dictionary<int, GameLang>();
    private static List<int> KeyList = new List<int>();
    /// <summary>
    /// 通过EquipId获取Csv1Config的实例
    /// </summary>
    /// <param name="EquipId">索引</param>
    /// <returns>Csv1Config的实例</returns>
    public static GameLang Get(int EquipId)
    {
        return dictionary[EquipId];
    }
    /// <summary>
    /// 获取字典
    /// </summary>
    /// <returns>字典</returns>
    public static Dictionary<int, GameLang> GetDictionary()
    {
        return dictionary;
    }
    public static List<int> GetAllKey()
    {
        return KeyList;
    }
}