using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChange : MonoBehaviour
{
    public int index;
    private PlayerController player;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Time.timeScale = 0;
    }

    void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = player.ownSkill[index];
    }

    public void OnClicked()
    {
        player.DeleteSkill(player.ownSkill[index]);
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }
}
