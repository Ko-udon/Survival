using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DynamicJoystick : Joystick
{
    tutorial_1Manager tutoManager;
    
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;

    protected override void Start()
    {
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(false);
        if(SceneManager.GetActiveScene().name=="Tutorial_1")
        {
            tutoManager = GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();
        }
        //tutoManager = GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();

    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        if(tutoManager!=null)
        {
            tutoManager.clickCount++;
            if(tutoManager.clickCount==2)
            {
                tutoManager.flow_2();
            }
        }

    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            //background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }


}