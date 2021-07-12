using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interview
{
    public class Popup_ShopItemInfo : Popup
    {
        [SerializeField] private Image iconImg;
        [SerializeField] private TMP_Text titleTxt;
        [SerializeField] private TMP_Text descTxt;
        
        public void Init(ShopItemData data)
        {
            iconImg.sprite = data.iconSpr;
            titleTxt.text = data.title;
            descTxt.text = data.desc;
        }
        
        protected override void OnShow()
        {
            
        }

        protected override void OnHide()
        {
            
        }
    }
}