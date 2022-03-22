using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick2 : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    bool bTouch = false;

    public RectTransform rectBack;
    public RectTransform rectJoystick;

    public Transform player;
    float m_fRadius;
    //float m_fSqr = 0f;

    Vector3 vecMove;

    Vector2 vecNormal;

    public float Speed = 5.0f;

    void Start()
    {
        //rectBack = transform.Find("Joystick2").GetComponent<RectTransform>();
        //rectJoystick = transform.Find("Joystick2/Joystick").GetComponent<RectTransform>();

        //player = GameObject.Find("Player").transform;

        m_fRadius = rectBack.rect.width * 0.5f;
    }

    void Update()
    {
        if (bTouch)
        {
            player.position += vecMove;
        }

    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2(vecTouch.x - rectBack.position.x, vecTouch.y - rectBack.position.y);


        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        rectJoystick.localPosition = vec;


        float fSqr = (rectBack.position - rectJoystick.position).sqrMagnitude / (m_fRadius * m_fRadius);


        Vector2 vecNormal = vec.normalized;

        vecMove = new Vector3(vecNormal.x * Speed * Time.deltaTime * fSqr, 0f, vecNormal.y * Speed * Time.deltaTime * fSqr);
        player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        bTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        rectJoystick.localPosition = Vector2.zero;
        bTouch = false;
    }
}
