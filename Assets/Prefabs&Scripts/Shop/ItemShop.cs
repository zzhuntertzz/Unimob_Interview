using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interview
{
    [RequireComponent(typeof(LeanButton))]
    public class ItemShop : MonoBehaviour
    {
        private ShopItemData data;
        private LeanButton btn;
        
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text nameTxt;
        [SerializeField] private TMP_Text priceTxt;

        private void Start()
        {
            btn = GetComponent<LeanButton>();
            btn.OnClick.AddListener(ShowInfo);
        }

        private void ShowInfo()
        {
            PopupManager.I.Show<Popup_ShopItemInfo>().Init(data);
        }

        public void Init(ShopItemData data)
        {
            this.data = data;
            icon.sprite = data.iconSpr;
            nameTxt.text = data.title;
            priceTxt.text = $"{data.price}";
        }
    }
}