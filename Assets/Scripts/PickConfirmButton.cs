using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickConfirmButton : MonoBehaviour
{
    public PlantieOptionButton pickedOptionButton;
    private PlantieHandler assignedPlantie;
    private PlayerHandler player;
    private Canvas pickUI;

    public Canvas gameUI;
    public TMP_InputField playerField;
    private Image plantieSprite;

    public popupButton popup;

    private string plantieName;
    public Product firstPlantie;

    // Start is called before the first frame update
    void Start()
    {
        plantieSprite = gameUI.transform.Find("Pot").Find("PlantieSprite").GetComponentInChildren<Image>();

        if (gameUI.enabled) gameUI.gameObject.SetActive(false);

        pickUI = transform.GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPlantieToBackpack()
    {
       firstPlantie.productName = assignedPlantie.Name;
       firstPlantie.productSprite = assignedPlantie.plantieSprites[0].sprite;
       firstPlantie.isBought = true;
       firstPlantie.productPrice = 0;
       player.playerInventory.Add(firstPlantie);
    }

    public void CloseUI()
    {
        if (pickedOptionButton)
        {
            assignedPlantie = pickedOptionButton.assignedPlantie;

            player = pickedOptionButton.player;
            player.gameObject.SetActive(true);

            if (playerField.text != "")
            {
                pickUI.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(true);
                plantieSprite.gameObject.SetActive(false);
                player.playerNameTMP.text = "Gracz: " + playerField.text;
                AddPlantieToBackpack();
            }
            else
            {
                popup.showPopup("Musisz podac swoje imie!", pickUI.GetComponent<CanvasGroup>());
            }
        }
        else popup.showPopup("Musisz wybrac roslinke!", pickUI.GetComponent<CanvasGroup>());
    }
}