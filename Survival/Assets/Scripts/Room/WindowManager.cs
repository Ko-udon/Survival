using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour
{
    public int layer;
    public string UItag;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.gameManager.maxLayer < this.layer)
        {
            GameManager.gameManager.maxLayer = this.layer;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(GameManager.gameManager.maxLayer == this.layer)
            {
                if (EventSystem.current.currentSelectedGameObject.tag != UItag)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }


    }
}
