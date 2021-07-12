using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interview
{
    public partial class Data
    {
        [SerializeField] private TextAsset shopDataJson;
        [SerializeField] private string iconPath;
        public ShopData shopData;
        
        [ContextMenu("LoadShopData")]
        public void LoadShopData()
        {
            shopData = JsonUtility.FromJson<ShopData>(shopDataJson.text);
            shopData.LoadIcon(iconPath);
        }
    }

    [Serializable]
    public class ShopData
    {
        public ShopItemData[] items;

        public void LoadIcon(string path)
        {
#if UNITY_EDITOR
            foreach (var item in items)
            {
                item.iconSpr = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>($"{path}/{item.icon}.png");
            }
#endif
        }
    }
    
    [Serializable]
    public class ShopItemData
    {
        public int id;
        public string icon;
        public Sprite iconSpr;
        public string title;
        public string desc;
        public int price;
    }
}