using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{
    public PlayerHandler player;
    public CanvasGroup backgroundUI;

    public List<BackpackSlot> backpackSlots;

    // Start is called before the first frame update
    void Start()
    {
        backpackSlots.AddRange(transform.Find("BackpackImage").Find("EqSlots").GetComponentsInChildren<BackpackSlot>());
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBackpack()
    {
        foreach (var slot in backpackSlots) slot.UpdateSlot();
        gameObject.SetActive(true);
        backgroundUI.interactable = false;
        backgroundUI.blocksRaycasts = false;
    }

    public void CloseBackpack()
    {
        gameObject.SetActive(false);
        backgroundUI.interactable = true;
        backgroundUI.blocksRaycasts = true;
    }
}
