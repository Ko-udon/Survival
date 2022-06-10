using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillList : MonoBehaviour
{
    private PlayerController player;

    public List<Sprite> imageList;
    private Dictionary<string, Sprite> skillList;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        skillList = new Dictionary<string, Sprite>();
        skillList.Add("Ball", imageList[0]);
        skillList.Add("KnockBack", imageList[1]);
        skillList.Add("Nautilus", imageList[2]);
        skillList.Add("Taunt", imageList[3]);
        skillList.Add("Virus", imageList[4]);
    }

    // Update is called once per frame
    void Update()
    {
        /*for(int i = 0; i < 3; i++)
        {
            if(player.ownSkill.Count >= i + 1)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = skillList[player.ownSkill[i]];
                transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = null;
                transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0);

            }
        }*/
        

    }
}
