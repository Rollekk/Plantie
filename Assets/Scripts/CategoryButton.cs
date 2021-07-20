using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    private ShopButton shopButton;
    private Button pickedCategory;
    public ProductPanel[] productPanel;

    public int buttonID;

    // Start is called before the first frame update
    void Start()
    {
        shopButton = GetComponentInParent<ShopButton>();
        pickedCategory = GetComponentInChildren<Button>();

        for (int i = 0; i < productPanel.Length; i++) productPanel[i].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowCategory()
    {
        if(productPanel[0].gameObject.activeInHierarchy)
        {
            for (int i = 0; i < productPanel.Length; i++) productPanel[i].ShowProducts(buttonID);
        }
        else
        {
            for (int i = 0; i < productPanel.Length; i++) productPanel[i].gameObject.SetActive(true);
        }
    }
}
