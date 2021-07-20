using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotHandler : MonoBehaviour
{
    [SerializeField] private Image[] soilStage;
    private int soilClickCount;
    private UseOptionButton useOption;
    public PlayerHandler player;

    public float waterValue;
    public float foodValue;

    private bool collisionStay;
    private Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        soilClickCount = 2;
        soilStage = new Image[3];
        soilStage = transform.Find("Soil").GetComponentsInChildren<Image>();

        foreach (var image in soilStage) image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(collisionStay)
        {
            if (player.plantieSprite.IsActive())
            {
                if (collision.tag == "Can")
                {
                    AddWater();
                }
                else if (collision.tag == "Food")
                {
                    AddFood();
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        useOption = collision.GetComponentInChildren<UseOptionButton>();
        if (player.plantieSprite.IsActive())
        {
            if (useOption)
            {
                useOption.particles.Play();
                collisionStay = true;
                this.collision = collision;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (useOption)
        {
            useOption.particles.Stop();
            useOption = null;
            collisionStay = false;
            this.collision = null;
        }
    }

    public void AddSoil()
    {
        if(soilClickCount >= 0)
        {
            soilStage[soilClickCount].gameObject.SetActive(true);
            soilClickCount--;

            if (soilClickCount < 0) player.isPotFull = true;
        }
    }

    void AddWater()
    {
       player.waterMeter += waterValue * Time.deltaTime;
    }

   void AddFood()
    {
       player.foodMeter += foodValue * Time.deltaTime;  
    }
}
