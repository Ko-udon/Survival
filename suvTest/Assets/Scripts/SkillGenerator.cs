using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject knockBackPrefab;
    public GameObject tauntPrefab;
    public GameObject nautilusPrefab;
    public GameObject virusPrefab;

    private List<string> skillList;

    void Start()
    {
        skillList = new List<string>();

        skillList.Add("Ball");
        skillList.Add("KnockBack");
        skillList.Add("Taunt");
        skillList.Add("Nautilus");
        skillList.Add("Virus");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            string skill = skillList[Random.Range(0, 5)];
            GenerateSkill(skill, transform.position + new Vector3(2, 0, 0));
        }
    }

    public void GenerateSkill(string type, Vector3 pos)
    {
        switch (type)
        {
            case "Ball":
                GameObject Get_Ball = Instantiate(ballPrefab, pos, Quaternion.Euler(0, 0, 0));
                break;

            case "KnockBack":
                GameObject Get_KnockBack = Instantiate(knockBackPrefab, pos, Quaternion.Euler(0, 0, 0));
                break;

            case "Taunt":
                GameObject Get_Taunt = Instantiate(tauntPrefab, pos, Quaternion.Euler(0, 0, 0));
                break;

            case "Nautilus":
                GameObject Get_Nautilus = Instantiate(nautilusPrefab, pos, Quaternion.Euler(0, 0, 0));
                break;

            case "Virus":
                GameObject Get_Virus = Instantiate(virusPrefab, pos, Quaternion.Euler(0, 0, 0));
                break;
        }
    }
}
