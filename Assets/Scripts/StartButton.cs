using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Canvas StartUI;
    private TMP_Text ButtonText;
    public Canvas PickUI;


    // Start is called before the first frame update
    void Start()
    {
        StartUI = transform.GetComponentInParent<Canvas>();
        ButtonText = transform.GetComponentInChildren<TMP_Text>();
        ButtonText.gameObject.SetActive(false);
        PickUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverStart()
    {
        ButtonText.gameObject.SetActive(true);
    }

    public void OnHoverEnd()
    {
        ButtonText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        StartUI.gameObject.SetActive(false);
        PickUI.gameObject.SetActive(true);
    }
}
