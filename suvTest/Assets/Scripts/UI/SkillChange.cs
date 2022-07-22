using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChange : MonoBehaviour
{
    public int index;
    private PlayerController player;
    SkillList skillIcon;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        skillIcon = FindObjectOfType<SkillList>();
        Time.timeScale = 0;
    }

    void Update()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = skillIcon.GetSprite(player.ownSkill[index]);
    }

    public void OnClicked()
    {
        player.DeleteSkill(player.ownSkill[index]);
        Time.timeScale = 1;
        if (index != 3)
        {
            skillIcon.BGAni(2);
        }
        transform.parent.gameObject.SetActive(false);
    }
}
