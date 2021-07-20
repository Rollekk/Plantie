using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public PlayerHandler player;
    public Canvas[] otherUIs;

    private bool shouldDisableUIs = true;
    private TMP_Text Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats = transform.Find("Statistics").GetComponentInChildren<TMP_Text>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled && shouldDisableUIs) 
        {
            foreach (var ui in otherUIs) ui.gameObject.SetActive(false);

            Stats.text = "Zdobyte monety: " + player.playerCurrency;
            Stats.text += "\n" + "Uzyskany poziom: " + player.plantieLevelTMP.text;

            shouldDisableUIs = false;
        }
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
