using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductPanel : MonoBehaviour
{
    private Button buyButton;
    public PlayerHandler player;
    public popupButton popup;
    public CanvasGroup shopImage;

    public Product[] productsArray;

    private Image productImage;
    private TMP_Text productPrice;
    private bool bought;
    private int startID;

    // Start is called before the first frame update
    void Start()
    {
        buyButton = GetComponentInChildren<Button>();

        productImage = transform.Find("ProductImage").GetComponentInChildren<Image>();
        productPrice = productImage.GetComponentInChildren<TMP_Text>();

        ShowProducts(startID);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyProduct()
    {
        if (player.playerCurrency >= int.Parse(productPrice.text))
        {
            player.playerCurrency -= int.Parse(productPrice.text);
            productsArray[startID].isBought = true;
            buyButton.interactable = false;
            player.playerInventory.Add(productsArray[startID]);
        }
        else
        {
            popup.showPopup("Masz za malo monet !", shopImage);
        }
    }

    public void ShowProducts(int index)
    {
        if (productsArray[index].isBought) buyButton.interactable = false;
        else buyButton.interactable = true;
        startID = index;
        productImage.sprite = productsArray[index].productSprite;
        productPrice.text = productsArray[index].productPrice.ToString();
    }
}
