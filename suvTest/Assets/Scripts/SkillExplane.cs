using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillExplane : MonoBehaviour
{
    public string skillName;
    private int skillLV;
    public int index;

    public GameObject name;
    public GameObject icon;
    public GameObject explane;

    PlayerController player;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        skillLV = player.maxLV[index];
        if(skillLV == 0)
        {
            name.GetComponent<Text>().text = "πÃ»πµÊ Ω∫≈≥";
            explane.SetActive(false);
        }
        else
        {
            name.GetComponent<Text>().text = skillName + " (LV " + skillLV + ")";
            explane.SetActive(true);
        }
        EnAbleSkillIcon(skillLV);
    }

    void EnAbleSkillIcon(int level)
    {
        for(int i = 0; i < icon.transform.childCount; i++)
        {
            if(i + 1 <= level)
            {
                icon.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                icon.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        
    }
}
