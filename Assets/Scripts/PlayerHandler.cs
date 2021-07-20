using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [Header("Player")]
    public string playerName;
    public Canvas gameOverUI;

    [Header("Plantie")]
    public PlantieHandler choosenPlantie;
    public PotHandler pot;
    public Image plantPotSprite;

    [Header("Sliders")]
    public Slider WaterSlider;
    public Slider FoodSlider;
    public Slider ExperienceSlider;
    private TMP_Text waterSliderText;
    private Color defaultWaterColor;
    private TMP_Text foodSliderText;
    private Color defaultFoodColor;

    [Header("Currency")]
    public TMP_Text textCurrency;
    public int playerCurrency;
    public List<Product> playerInventory;

    [Header("Meters")]
    [SerializeField] private int Level;
    public float waterMeter;
    public float waterUse;
    public int sprayDMG = 2;

    public float foodMeter;
    public float foodUse;

    public float experienceMeter;
    public bool isPotFull;
    public bool isPlantDead;
    private int levelsDown = 0;

    [SerializeField] private float waterDrain = 0.5f;
    [SerializeField] private float foodDrain = 0.5f;
    public float experienceGain = 5f;
    public TMP_Text playerNameTMP;
    public TMP_Text plantieNameTMP;
    public TMP_Text plantieLevelTMP;
    public Image plantieSprite;

    // Start is called before the first frame update
    void Start()
    {
        textCurrency.text = playerCurrency.ToString();

        ExperienceSlider.gameObject.SetActive(false);
        WaterSlider.maxValue = choosenPlantie.waterNeeded;
        FoodSlider.maxValue = choosenPlantie.foodNeeded;
        ExperienceSlider.maxValue = choosenPlantie.experienceNeeded;

        plantieNameTMP.gameObject.SetActive(false);
        plantieLevelTMP.gameObject.SetActive(false);

        waterSliderText = WaterSlider.GetComponentInChildren<TMP_Text>();
        foodSliderText = FoodSlider.GetComponentInChildren<TMP_Text>();

        defaultWaterColor = waterSliderText.color;
        defaultFoodColor = foodSliderText.color;

        Level = 0;
        waterMeter = 0.0f;
        WaterSlider.value = waterMeter;
        foodMeter = 0.0f;
        FoodSlider.value = foodMeter;
        experienceMeter = 0.0f;
        ExperienceSlider.value = experienceMeter;
    }

    // Update is called once per frame
    void Update()
    {
        textCurrency.text = playerCurrency.ToString();

        if (plantieSprite.IsActive())
        {
            UpdateSliders();
            UpdateLevel();
            UpdateCurrency();

            if (waterMeter >= WaterSlider.maxValue) UpdateTextColor(waterSliderText, defaultWaterColor);
            else SetToDefaultColor(waterSliderText, defaultWaterColor);
            if (foodMeter >= FoodSlider.maxValue) UpdateTextColor(foodSliderText, defaultFoodColor);
            else SetToDefaultColor(foodSliderText, defaultFoodColor);

            UpdateUses();
        }
    }

    private void AddExperience()
    {
        if (waterMeter > WaterSlider.maxValue || foodMeter > FoodSlider.maxValue)
        {
            experienceMeter -= (float)(experienceGain * Time.deltaTime) / 2;
        }
        else if (waterMeter >= (WaterSlider.maxValue / 6) && foodMeter >= (FoodSlider.maxValue / 6))
        {
            experienceMeter += experienceGain * Time.deltaTime;
            waterUse -= Time.deltaTime;
            foodUse -= Time.deltaTime;
        }
        else if(waterMeter <= 0 || foodMeter <= 0)
        {
            experienceMeter -= experienceGain * Time.deltaTime;
        }
    }

    private void UpdateTextColor(TMP_Text textToChange, Color defaultColor)
    {
        textToChange.color = Color.Lerp(defaultColor, Color.red, Mathf.PingPong(Time.time, 1));
    }

    private void SetToDefaultColor(TMP_Text textToChange, Color defaultColor)
    {
        textToChange.color = defaultColor;
    }

    private void UpdateUses()
    {
        if(foodUse <= 0)
        {
            foodUse = 100;
            experienceGain = 5f;
        }

        if(waterUse <= 0)
        {
            waterUse = 100;
            experienceGain = 5f;
        }
    }

    private void UpdateSliders()
    {
        WaterSlider.value = waterMeter;
        FoodSlider.value = foodMeter;
        ExperienceSlider.value = experienceMeter;

        if(waterMeter > 0)
        {
            waterMeter -= waterDrain * Time.deltaTime;
        }
        if (foodMeter > 0)
        {
            foodMeter -= foodDrain * Time.deltaTime;
        }

        AddExperience();
    }

    private void UpdateLevel()
    {
        if(experienceMeter >= ExperienceSlider.maxValue)
        {
            LevelUp();
        }
        else if(experienceMeter < ExperienceSlider.minValue)
        {
            if (Level > 0)
            {
                SubLevel();
            }
            else
            {
                ResetLevel();
            }
            
        }

        plantieLevelTMP.text = "Poziom " + Level;
    }

    private void ResetLevel()
    {
        Level = 0;
        experienceMeter = ExperienceSlider.minValue;
    }

    private void SubLevel()
    {
        Level--;
        experienceMeter = ExperienceSlider.maxValue;
        if (choosenPlantie.isFullyGrown) 
        {
            SwapPlantieSprite();
            choosenPlantie.isFullyGrown = false;
        }
        else SwapPlantieSprite();
    }

    private void AddBonusCurrency(int amountOfCurrency)
    {
        playerCurrency += amountOfCurrency * Level;
    }

    private void UpdateCurrency()
    {
        textCurrency.text = playerCurrency.ToString();
    }

    private void SwapPlantieSprite()
    {
        Debug.Log("DOWN");
        if(levelsDown == 2)
        {
            gameOverUI.gameObject.SetActive(true);
        }
        else
        {
            if(Level >= choosenPlantie.plantieGrowthSprites.Length - 1) plantieSprite.sprite = choosenPlantie.plantieDyingSprites[choosenPlantie.plantieGrowthSprites.Length - 1];
            else plantieSprite.sprite = choosenPlantie.plantieDyingSprites[Level];
            plantieSprite.SetNativeSize();
            levelsDown++;
        }
    }

    private void ChangePlantieSprite()
    {
        plantieSprite.sprite = choosenPlantie.plantieGrowthSprites[Level];
        plantieSprite.SetNativeSize();
    }

    private void HarvestPlantieFruits()
    {
        choosenPlantie.isFullyGrown = true;
        AddBonusCurrency(100);
    }

    private void LevelUp()
    {
        Level++;
        experienceMeter = 0;

        if (Level < choosenPlantie.plantieGrowthSprites.Length) ChangePlantieSprite();
        else HarvestPlantieFruits();

        AddBonusCurrency(50);
    }

    public void AddBonusExperience(float bonusExperience)
    {
        experienceMeter += bonusExperience;
    }
}
