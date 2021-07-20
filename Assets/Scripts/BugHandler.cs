using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHandler : MonoBehaviour
{
    private UseOptionButton useOption;
    private Animator bugAnimator;
    private float bugHP = 1f;

    public PlayerHandler player;
    private bool shouldPlayAnim = true;

    // Start is called before the first frame update
    void Start()
    {
        bugAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bugHP <= 0f) Destroy(this.gameObject);
        else AttackPlantie();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bug")
        {
            useOption = collision.GetComponentInChildren<UseOptionButton>();
            if (useOption)
            {
                useOption.particles.Play();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bug")
        {
            useOption = collision.GetComponentInChildren<UseOptionButton>();
            if (useOption)
            {
                bugHP -= Time.deltaTime * player.sprayDMG;
                player.sprayDMG = 2;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (useOption)
        {
            useOption.particles.Stop();
            useOption = null;
        }
    }

    private void AttackPlantie()
    {
        player.experienceMeter = 0;
        player.waterMeter -= bugHP * Time.deltaTime;
        player.foodMeter -= bugHP * Time.deltaTime;

        if (shouldPlayAnim)
        {
            bugAnimator.Play("BugIdle", 0, 0f);
            shouldPlayAnim = false;
        }
    }
}
