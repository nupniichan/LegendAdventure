using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentpanel;
    List<UIInventoryItem> ListOfItems = new List<UIInventoryItem>();
    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentpanel);
            ListOfItems.Add(uiItem);
            uiItem.OnItemClick += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDropOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleSwap(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
