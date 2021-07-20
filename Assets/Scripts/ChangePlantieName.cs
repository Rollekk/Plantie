using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class ChangePlantieName : MonoBehaviour
{
    public PlayerHandler player;
    public CanvasGroup shopImage;
    public popupButton popup;

    private TMP_InputField newNameField;
    private TMP_Text buttonPrice;
    [SerializeField] private int nameChangePrice = 210;

    // Start is called before the first frame update
    void Start()
    {
        newNameField = transform.Find("ChangeNameField").GetComponentInChildren<TMP_InputField>();
        buttonPrice = transform.Find("ChangeNameButton").GetComponentInChildren<TMP_Text>();

        buttonPrice.text = nameChangePrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeName()
    {
        if (player.playerCurrency >= nameChangePrice)
        {
            if (newNameField.text != "")
            {
                player.plantieNameTMP.text = newNameField.text;
                player.playerCurrency -= nameChangePrice;
                popup.showPopup("Nazwe zmieniono na " + player.plantieNameTMP.text, shopImage);
            }
            else popup.showPopup("Musisz podac nowa nazwe !", shopImage);
        }
        else popup.showPopup("Masz za malo monet !", shopImage);

    }
}
