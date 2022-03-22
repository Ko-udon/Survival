using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Joystick_ko : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    bool btTouch = false;

    public Transform player;

    public RectTransform rectBack;
    public RectTransform rectJoystick;
    float radius;

    private Vector3 value;
    public float speed = 80.0f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").transform;

        //rectBack = transform.Find("JoystickBack").GetComponent<RectTransform>();
        //rectJoystick = transform.Find("JoystickBack/Joystick").GetComponent<RectTransform>();
        radius = rectBack.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (btTouch)
        {
            //rotate
            if (this.value.x > this.value.y)
            {
                player.transform.Rotate(Vector3.up * Time.deltaTime * speed);
            }
            else if (this.value.x < this.value.y)
            {
                player.transform.Rotate(Vector3.up * Time.deltaTime * (-speed));
            }

        }

    }


    void OnTouch(Vector2 vecTouch)
    {
        //Vector2 vec = new Vector2(vecTouch.x - player_rectBack.position.x, vecTouch.y - player_rectBack.position.y);

        Vector2 vec = new Vector2(vecTouch.x - rectBack.position.x, 0f);

        value = Vector2.ClampMagnitude(vec, radius);
        rectJoystick.localPosition = value;

        value = value.normalized;



        /*
                vec = Vector2.ClampMagnitude(vec, 15f);
                rectJoystick.localPosition = vec;

                //float sqr = (rectBack.position - rectJoystick.position).sqrMagnitude / (radius * radius);

                Vector2 vecNormal = vec.normalized;
                player_vecMove = new Vector3(0, 0f, vecNormal.y * Time.deltaTime);
                player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * 60f, 0f);*/


        //player_vecMove = new Vector3(0, 0f, vecNormal.y * Time.deltaTime * sqr);
        //player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);



    }


    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        btTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        btTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        rectJoystick.transform.localPosition = new Vector3(0, 0, 0);
        btTouch = false;
    }

}
