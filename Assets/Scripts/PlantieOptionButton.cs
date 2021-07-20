using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantieOptionButton : MonoBehaviour
{
    public PickConfirmButton confirmButton;
    public PlantieHandler assignedPlantie;
    public PlayerHandler player;

    private Button optionButton;
    private TMP_Text buttonText;

    private Canvas pickUI;
    public TMP_Text plantieName;
    public Image[] plantieStages;

    // Start is called before the first frame update
    void Start()
    {
        pickUI = transform.GetComponentInParent<Canvas>();

        plantieStages = new Image[3];
        for (int i = 0; i < 3; i++)
        {
            plantieStages[i] = pickUI.transform.Find("PlantieStage." + i).GetComponentInChildren<Image>();
            plantieStages[i].gameObject.SetActive(false);
        }
        plantieName = pickUI.transform.Find("PlantieName").GetComponent<TMP_Text>();

        optionButton = transform.GetComponentInChildren<Button>();
        buttonText = optionButton.transform.GetComponentInChildren<TMP_Text>();
        buttonText.text = assignedPlantie.Name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignPlantie()
    {
        player.choosenPlantie = assignedPlantie;
        plantieName.text = assignedPlantie.Name;
        for(int i = 0; i < plantieStages.Length; i++)
        {
            plantieStages[i].gameObject.SetActive(true);
            plantieStages[i].sprite = assignedPlantie.plantieSprites[i].sprite;
        }
        confirmButton.pickedOptionButton = this;
        optionButton.Select();
    }
}
