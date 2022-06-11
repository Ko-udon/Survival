using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillList : MonoBehaviour
{
    private PlayerController player;

    public List<Sprite> imageList;

    private List<Animator> bgIcon;
    private List<Image> skillIcon;
    private Dictionary<string, Sprite> skillList_1;
    private Dictionary<string, Sprite> skillList_2;
    private Dictionary<string, Sprite> skillList_3;
    private Dictionary<string, Sprite> skillList_4;
    private Dictionary<string, Sprite> skillList_5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        skillList_1 = new Dictionary<string, Sprite>();
        skillList_1.Add("Ball", imageList[0]);
        skillList_1.Add("KnockBack", imageList[1]);
        skillList_1.Add("Nautilus", imageList[2]);
        skillList_1.Add("Taunt", imageList[3]);
        skillList_1.Add("Virus", imageList[4]);

        skillList_2 = new Dictionary<string, Sprite>();
        skillList_2.Add("Ball", imageList[5]);
        skillList_2.Add("KnockBack", imageList[6]);
        skillList_2.Add("Nautilus", imageList[7]);
        skillList_2.Add("Taunt", imageList[8]);
        skillList_2.Add("Virus", imageList[9]);

        skillList_3 = new Dictionary<string, Sprite>();
        skillList_3.Add("Ball", imageList[10]);
        skillList_3.Add("KnockBack", imageList[11]);
        skillList_3.Add("Nautilus", imageList[12]);
        skillList_3.Add("Taunt", imageList[13]);
        skillList_3.Add("Virus", imageList[14]);

        skillList_4 = new Dictionary<string, Sprite>();
        skillList_4.Add("Ball", imageList[15]);
        skillList_4.Add("KnockBack", imageList[16]);
        skillList_4.Add("Nautilus", imageList[17]);
        skillList_4.Add("Taunt", imageList[18]);
        skillList_4.Add("Virus", imageList[19]);

        skillList_5 = new Dictionary<string, Sprite>();
        skillList_5.Add("Ball", imageList[20]);
        skillList_5.Add("KnockBack", imageList[21]);
        skillList_5.Add("Nautilus", imageList[22]);
        skillList_5.Add("Taunt", imageList[23]);
        skillList_5.Add("Virus", imageList[24]);

        bgIcon = new List<Animator>();
        bgIcon.Add(transform.GetChild(0).GetComponent<Animator>());
        bgIcon.Add(transform.GetChild(1).GetComponent<Animator>());
        bgIcon.Add(transform.GetChild(2).GetComponent<Animator>());

        skillIcon = new List<Image>();
        skillIcon.Add(transform.GetChild(3).GetComponent<Image>());
        skillIcon.Add(transform.GetChild(4).GetComponent<Image>());
        skillIcon.Add(transform.GetChild(5).GetComponent<Image>());
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            if(player.ownSkill.Count >= i + 1)
            {
                switch(player.GetSkillLV(player.ownSkill[i]))
                {
                    case 1:
                        skillIcon[i].sprite = skillList_1[player.ownSkill[i]];
                        break;

                    case 2:
                        skillIcon[i].sprite = skillList_2[player.ownSkill[i]];
                        break;

                    case 3:
                        skillIcon[i].sprite = skillList_3[player.ownSkill[i]];
                        break;

                    case 4:
                        skillIcon[i].sprite = skillList_4[player.ownSkill[i]];
                        break;

                    case 5:
                        skillIcon[i].sprite = skillList_5[player.ownSkill[i]];
                        break;
                }
                skillIcon[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                skillIcon[i].sprite = null;
                skillIcon[i].color = new Color(1, 1, 1, 0);

            }
        }
    }

    public void BGAni(int index)
    {
        bgIcon[index].SetTrigger("Fade");
    }
}
