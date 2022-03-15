using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//특정 터치영역에 속할때만 조이스틱 활성화를 위한 코드
public class TouchArea : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public GameObject joystick;
    private float xAngle;
    private float yAngle;
    private float xAngleTemp;
    private float yAngleTemp;
    Vector2 beginPos;
    Vector2 draggingPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData data)
    {
        beginPos = data.position;
        xAngleTemp = xAngle;
        yAngleTemp = yAngle;
        joystick.transform.position = beginPos;
        joystick.gameObject.SetActive(true);
    }
    public void OnEndDrag(PointerEventData data)
    {
        joystick.gameObject.SetActive(false);

    }
    public void OnDrag(PointerEventData draggingPoint)
    {
        draggingPos = draggingPoint.position;

    }
}
