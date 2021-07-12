using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mopsicus.InfiniteScroll;
using UnityEngine;

namespace Interview
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ItemShop itemShopPref;
        [SerializeField] private RectTransform itemBoardPref;
        // [SerializeField] private Transform itemView;

        [SerializeField] private InfiniteScroll Scroll;

        [SerializeField] private int itemPerBoard = 3;
        private int Count;
        private ShopItemData[] lstShopItemData;

        
        // Start is called before the first frame update
        void Start()
        {
            Scroll.OnFill += OnFillItem;
            Scroll.OnHeight += OnHeightItem;

            lstShopItemData = Data.I.shopData.items;
            Count = lstShopItemData.Length / itemPerBoard;
            if (lstShopItemData.Length % itemPerBoard != 0) Count++;
            Scroll.InitData(Count);

            // InitItems();
        }

        void OnFillItem (int index, GameObject item) {
            // item.GetComponentInChildren<Text> ().text = index.ToString ();
            for (int i = 0; i < itemPerBoard; i++)
            {
                int itemIndex = index * itemPerBoard + i;
                if (item.transform.GetChild(0).childCount > i)
                {
                    item.transform.GetChild(0).GetChild(i)
                        .GetComponent<ItemShop>()
                        .Init(lstShopItemData[itemIndex]);
                }
                else
                {
                    Instantiate(itemShopPref, item.transform.GetChild(0))
                        .Init(lstShopItemData[itemIndex]);
                }
            }
        }
        
        int OnHeightItem (int index)
        {
            return (int) itemBoardPref.sizeDelta.y;
        }

        // private void InitItems()
        // {
        //     var lstItems = Data.I.shopData.items.Take(7).ToList();
        //     List<Transform> lstBoards = new List<Transform>();
        //     int itemPerBoard = 3;
        //     for (int i = 0; i < 7; i++)
        //     {
        //         if (i % itemPerBoard == 0)
        //             lstBoards.Add(Instantiate(itemBoardPref, itemView));
        //         var newItem = Instantiate(itemShopPref, lstBoards[i / itemPerBoard].GetChild(0));
        //         newItem.Init(lstItems[i]);
        //     }
        // }
    }
}