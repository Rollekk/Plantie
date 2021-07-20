using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackpackSlot : MonoBehaviour
{
    public int slotID;

    private Product product;
    private Image slotImage;
    public PlayerHandler player;
    public popupButton popup;

    private bool canUse = false;

    // Start is called before the first frame update
    void Start()
    {
        slotImage = transform.Find("Image").GetComponentInChildren<Image>();
        if (product) product = player.playerInventory[slotID];
        if (slotID < player.playerInventory.Count) slotImage.sprite = product.productSprite;
        slotImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UseSlot()
    {
        if(canUse)
        {
            if (product.tag == "Seed")
            {
                if (player.isPotFull) UseSeed();
            }
            else if(product.tag == "Pot")
            {
                if (player.plantieSprite.IsActive()) UsePot();
            }
            else if (product.tag == "Bug")
            {
                if (player.plantieSprite.IsActive()) UseBug();
            }
            else if (product.tag == "Food")
            {
                if (player.plantieSprite.IsActive()) UseFood();
            }
        }
    }

    public void UpdateSlot()
    {
        if (slotID < player.playerInventory.Count)
        {
            product = player.playerInventory[slotID];
            slotImage.sprite = product.productSprite;
            slotImage.gameObject.SetActive(true);
            canUse = true;
        }
    }

    private void UseSeed()
    {
        if (!player.choosenPlantie.gameObject.activeInHierarchy)
        {
            player.plantieSprite.sprite = slotImage.sprite;
            player.plantieSprite.SetNativeSize();
            player.plantieSprite.gameObject.SetActive(true);
            player.ExperienceSlider.gameObject.SetActive(true);
            player.plantieNameTMP.gameObject.SetActive(true);
            player.plantieLevelTMP.gameObject.SetActive(true);
        }

        player.plantieLevelTMP.text = "Poziom 0";
        player.plantieNameTMP.text = product.productName;

        DeleteProduct();

        canUse = false;
    }

    private void UsePot()
    {
        Sprite tmpPot;
        tmpPot = player.plantPotSprite.sprite;
        player.plantPotSprite.sprite = slotImage.sprite;
        slotImage.sprite = tmpPot;
    }

    private void UseBug()
    {
        player.sprayDMG = product.productPrice / 100;
        player.AddBonusExperience((product.productPrice / 100) * (product.productPrice / 100));
        DeleteProduct();
    }

    private void UseFood()
    {
        player.experienceGain = (float) product.productPrice / 100;
        player.foodUse = 10;
        DeleteProduct();
    }

    private void DeleteProduct()
    {
        slotImage.gameObject.SetActive(false);
        player.playerInventory.Remove(product);
    }
}
