using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseOptionButton : MonoBehaviour
{
    private Vector2 defaultPosition;
    private bool canRotate = true;
    public Animator animator;
    public ParticleSystem particles;

    private CanvasGroup GameUI;

    private bool shouldStopParticles = true;

    void Start()
    {
        defaultPosition = transform.localPosition;
        GameUI = GetComponentInParent<CanvasGroup>();
    }

    private void Update()
    {
        if (isActiveAndEnabled && shouldStopParticles)
        {
            particles.Stop();
            shouldStopParticles = false;
        }
    }

    public void OnMouseEnter()
    {
        if (GameUI.blocksRaycasts) animator.Play("Highlighted");
    }

    public void OnMouseExit()
    {
        if (GameUI.blocksRaycasts) animator.Play("Normal");
    }

    public void OnMouseDrag()
    {
        if (GameUI.blocksRaycasts)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (canRotate)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
                canRotate = false;
            }
            transform.Translate(mousePosition);
        }
    }

    public void OnMouseUpAsButton()
    {
        if(GameUI.blocksRaycasts)
        {
            transform.localPosition = defaultPosition;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            canRotate = true;
        }
    }
}
