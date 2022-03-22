using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActivateBtn : MonoBehaviour
{
    public GameObject btn;
    private bool btnActivate=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Toogle()
    {
        if (!btnActivate)
        {
            btnActivate = true;
            btn.SetActive(true);
        }
        else
        {
            btnActivate = false;
            btn.SetActive(false);
        }
    }
}
