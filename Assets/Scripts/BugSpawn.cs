using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawn : MonoBehaviour
{
    public GameObject bugToSpawn;
    public PlayerHandler player;

    private float generateTime = 0.0f;
    private RectTransform rectTransform;
    public bool shouldSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponentInChildren<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.plantieSprite.IsActive())
        {
            if (shouldSpawn) SpawnBugs();
            generateTime += Time.deltaTime;
            if (generateTime >= 60.0f)
            {
                generateTime = 0.0f;
                if (Random.Range(0, 2) == 1) SpawnBugs();
            }
        }
    }

    public void SpawnBugs()
    {
        for (int i = 0; i < Random.Range(1, 6); i++)
        {
            float rangeX = Random.Range(-(rectTransform.rect.width / 2), rectTransform.rect.width / 2);
            float rangeY = Random.Range(-(rectTransform.rect.height / 2), rectTransform.rect.height / 2);

            Vector2 position = new Vector2(rangeX, rangeY);

            GameObject bugGO = Instantiate(bugToSpawn, transform.position, transform.rotation, transform);
            bugGO.transform.localPosition = position;
            bugGO.transform.localRotation = Quaternion.Euler(new Vector3(0f,0f,Random.Range(0f, 360f)));

            BugHandler newBug = bugGO.GetComponentInChildren<BugHandler>();
            newBug.player = player;
        }

        shouldSpawn = false;
    }
}
