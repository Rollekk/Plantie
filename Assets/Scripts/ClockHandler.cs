using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockHandler : MonoBehaviour
{
    private Image clockSprite;
    private Canvas gameUI;

    public bool stopClock = false;
    public int timeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        clockSprite = transform.Find("Clock").GetComponentInChildren<Image>();

        gameUI = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameUI.gameObject.activeInHierarchy && !stopClock) clockSprite.transform.RotateAround(clockSprite.transform.position, -Vector3.forward, timeSpeed * Time.deltaTime);
    }
}
