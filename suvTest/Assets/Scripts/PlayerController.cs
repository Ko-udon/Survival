using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float hp;

    public GameObject arrowPrefab;
    public GameObject playerCharacter;

    public GameObject skill_Ball;
    public GameObject skill_KnockBack;
    public GameObject skill_Taunt;
    public GameObject skill_Nautilus;
    public GameObject skill_Virus;

    public int Level=0;
    public int exp=0;
    public List<int> expList;
    public GameObject effectLvUp;


    public int ballLV;
    public int knockbackLV;
    public int tauntLV;
    public int nautilusLV;
    public int virusLV;
    //UI관련
    UIController ui;

    //Animation
    public Animation anim;
    public bool isIdle;


    void Start()
    {
        ballLV = 0;
        knockbackLV = 0;
        tauntLV = 0;
        nautilusLV = 0;
        virusLV = 0;

        ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
    }

    void Update()
    {
        
        CheckHP();

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -Time.deltaTime * speed);

        }

        //Animations
        if (isIdle == false)
        {
            anim.Play("Running");
        }
        else if (isIdle == true)
        {
            anim.Play("Idle");
        }
    }

    public void HitEffect(Vector3 hitPos)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform);
        arrow.GetComponent<HitArrow>().target = hitPos;
    }

    public void GetDamage(float atk)
    {
        hp = hp - atk;
        ui.PlayerHpBar();
    }
    public void CheckHP()
    {
        if (hp < 0)
        {
            //gameObject.SetActive(false);
            playerCharacter.SetActive(false);
        }
    }

    public void SetExp(int expAmount)
    {
        exp += expAmount;
        ui.SetExp();
        ui.PlayerExpBar();
       
        if (exp >= expList[Level])
        {
           
            LevelUp();
            //GameObject effect = Instantiate(effectLvUp, new Vector3(transform.position.x,transform.position.y-1,transform.position.z), effectLvUp.transform.rotation);
            effectLvUp.SetActive(true);
            exp = 0;
            ui.ResetPlayerExpBar();
            ui.SetLevel();
            ui.SetExp();
            //ui.PlayerExpBar();
        }
    }

    //set player status up in here
    public void LevelUp()
    {
        Level++;
        hp += 100;
    }
    public void Heal(float amount)
    {
        hp += amount;
        ui.PlayerHpBar();
    }
    public void GetSkill(string type)
    {
        switch(type)
        {
            case "Ball":
                ballLV++;
                if(ballLV == 1)
                {
                    skill_Ball.SetActive(true);
                    skill_Ball.GetComponent<BallController>().UpdateLV(ballLV);
                }
                else
                {
                    skill_Ball.GetComponent<BallController>().UpdateLV(ballLV);
                }
                break;

            case "KnockBack":
                knockbackLV++;
                if (knockbackLV == 1)
                {
                    skill_KnockBack.SetActive(true);
                    skill_KnockBack.GetComponent<KnockBack>().UpdateLV(knockbackLV);
                }
                else
                {
                    skill_KnockBack.GetComponent<KnockBack>().UpdateLV(knockbackLV);
                }
                break;

            case "Taunt":
                tauntLV++;
                if (tauntLV == 1)
                {
                    skill_Taunt.SetActive(true);
                    skill_Taunt.GetComponent<Taunt>().UpdateLV(tauntLV);
                }
                else
                {
                    skill_Taunt.GetComponent<Taunt>().UpdateLV(tauntLV);
                }
                break;

            case "Nautilus":
                nautilusLV++;
                if (nautilusLV == 1)
                {
                    skill_Nautilus.SetActive(true);
                    skill_Nautilus.GetComponent<Nautilus>().UpdateLV(nautilusLV);
                }
                else
                {
                    skill_Nautilus.GetComponent<Nautilus>().UpdateLV(nautilusLV);
                }
                break;

            case "Virus":
                virusLV++;
                if (virusLV == 1)
                {
                    skill_Virus.SetActive(true);
                    skill_Virus.GetComponent<PoisonGenerator>().UpdateLV(virusLV);
                }
                else
                {
                    skill_Virus.GetComponent<PoisonGenerator>().UpdateLV(virusLV);
                }
                break;
        }
    }
}
