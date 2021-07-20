using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class popupButton : MonoBehaviour
{
    public TMP_Text popupDescription;
    public Canvas popupUI;
    public CanvasGroup backgroundUI;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        popupDescription = transform.Find("Image").transform.Find("Description").GetComponentInChildren<TMP_Text>();
        popupUI = GetComponentInChildren<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closePopup()
    {
        backgroundUI.interactable = true;
        backgroundUI.blocksRaycasts = true;
        gameObject.SetActive(false);
    }

    public void showPopup(string Description, CanvasGroup BackgroundUI)
    {
        popupUI.gameObject.SetActive(true);
        backgroundUI = BackgroundUI;
        backgroundUI.interactable = false;
        backgroundUI.blocksRaycasts = false;
        popupDescription.text = Description;
    }
}
