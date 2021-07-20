using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    public Canvas changeUI;
    public CanvasGroup backgroundUI;
    public TMP_InputField newNameField;
    public TMP_Text Desc;
    public PlayerHandler player;

    [SerializeField] private int nameChangePrice = 210;

    // Start is called before the first frame update
    void Start()
    {
        Desc.text = "Podaj nowa nazwe:";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUI()
    {
        changeUI.gameObject.SetActive(true);
        backgroundUI.interactable = false;
        backgroundUI.blocksRaycasts = false;
    }

    public void BuyAndCloseUI()
    {
        if (player.playerCurrency >= nameChangePrice)
        {
            if (newNameField.text != "")
            {
                player.plantieNameTMP.text = newNameField.text;
                player.playerCurrency -= nameChangePrice;

                newNameField.text = "";
                changeUI.gameObject.SetActive(false);
                backgroundUI.interactable = true;
                backgroundUI.blocksRaycasts = true;
            }
            else Desc.text = "Musisz podac nowa nazwe!";
        }
        else Desc.text = "Nie masz tylu monet!";
    }

    public void CloseUI()
    {
        Desc.text = "Podaj nowa nazwe:";
        newNameField.text = "";
        changeUI.gameObject.SetActive(false);
        backgroundUI.interactable = true;
        backgroundUI.blocksRaycasts = true;
    }
}
