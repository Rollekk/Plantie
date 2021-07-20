using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantieHandler : MonoBehaviour
{
    public int Level;
    public string Name;
    public float waterNeeded;
    public float foodNeeded;
    public float experienceNeeded;
    public SpriteRenderer[] plantieSprites;
    public Sprite[] plantieGrowthSprites;
    public Sprite[] plantieDyingSprites;

    public bool isFullyGrown = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(name);
        plantieSprites = new SpriteRenderer[3];
        plantieSprites = transform.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 1; i < 3; i++) plantieSprites[i].gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeName(string newName) { Name = newName; }
}