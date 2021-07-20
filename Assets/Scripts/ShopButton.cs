using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    private Canvas shopUI;
    private CategoryButton[] CategoryButton;
    public CanvasGroup backgroundUI;
    public PlayerHandler player;

    public TMP_Text shopCurrency;
    private bool wasPlantieVisible;
    // Start is called before the first frame update
    void Start()
    {
        shopUI = GetComponentInChildren<Canvas>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shopCurrency.text = player.playerCurrency.ToString();
    }

    public void OpenShop()
    {
        shopUI.gameObject.SetActive(true);

        shopCurrency.text = player.playerCurrency.ToString();

        backgroundUI.interactable = false;
        backgroundUI.blocksRaycasts = false;
        if (player.choosenPlantie.gameObject.activeInHierarchy)
        {
            player.choosenPlantie.gameObject.SetActive(false);
            wasPlantieVisible = true;
        }
        else wasPlantieVisible = false;
    }

    public void CloseShop()
    {
        shopUI.gameObject.SetActive(false);
        backgroundUI.interactable = true;
        backgroundUI.blocksRaycasts = true;
        if(wasPlantieVisible) player.choosenPlantie.gameObject.SetActive(true);
    }
}
