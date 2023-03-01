using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage inventoryUI;
    public int InventorySize = 10;
    private void Start()
    {
        inventoryUI.InitializeInventoryUI(InventorySize);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}
