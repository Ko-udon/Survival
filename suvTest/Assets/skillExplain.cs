using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class skillExplain : MonoBehaviour
{
    public Sprite skillSprite;
    private Image skillImg;
    public Text skillText;

    public GameObject skillExplainBox;
    private PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        skillSprite = this.GetComponent<Image>().sprite;
        skillImg = this.GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
       
    }


    public void checkSkillChangeImgUI()
    {
        
        skillSprite = this.GetComponent<Image>().sprite;
        //Debug.Log(skillImg.name);
        if(skillSprite==null)
        {
            skillImg.raycastTarget = false;
        }
        else
        {
            skillImg.raycastTarget = true;
            if (skillSprite.name.Contains("Ball"))
            {

                skillText.text = "스킬 공Lv"+player.ballLV.ToString()+": 주위를 돌며 자동으로 공격해주는 공을 소환(+레벨에 따른 상세 설명 추가)";
            }
            else if (skillSprite.name.Contains("Knockback"))
            {
                skillText.text = "스킬 넉백Lv" + player.knockbackLV.ToString() + ": 일정 간격으로 폭발을 일으켜 주위의 적을 밀처낸다";
            }
            else if (skillSprite.name.Contains("Nautilus"))
            {
                skillText.text = "스킬 노틸러스Lv" + player.nautilusLV.ToString() + ": 일정 간격으로 적을 추적하는 물줄기를 발사한다";
            }
            else if (skillSprite.name.Contains("Taunt"))
            {
                skillText.text = "스킬 도발LV" + player.tauntLV.ToString() + ": 적들이 공격하는 도발물체를 생성한다";
            }
            else if (skillSprite.name.Contains("Virus"))
            {
                skillText.text = "스킬 바이러스Lv" + player.virusLV.ToString() + ": 적들에게 서서히 데미지를 주는 독을 뿌린다";
            }
        }


    }
    

    public void OnPointerEnter()
    {
        skillExplainBox.SetActive(true);
    }
    public void OnPointerExit()
    {
        skillExplainBox.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        checkSkillChangeImgUI();

    }
}
