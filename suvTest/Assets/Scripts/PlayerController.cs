using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool test;

    public string charName;
    public float speed;
    public float rotSpeed;
    public float hp;
    public float code;
    private int dir;

    public List<string> ownSkill;

    public GameObject arrowPrefab;
    public GameObject playerCharacter;

    public GameObject skill_Ball;
    public GameObject skill_KnockBack;
    public GameObject skill_Taunt;
    public GameObject skill_Nautilus;
    public GameObject skill_Virus;

    public GameObject skillChangeUI;

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
    StatusBattery statusBt;
    Rigidbody rigidbody;
    CharacterController collider;
    SkillList skillIcon;

    //Animation
    public Animation anim;
    public bool isIdle;


    //sound
    AudioSource audio;
    public AudioClip hitsound;

    void Start()
    {
        ballLV = 0;
        knockbackLV = 0;
        tauntLV = 0;
        nautilusLV = 0;
        virusLV = 0;

        rigidbody = GetComponent<Rigidbody>();
        ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        collider = GetComponent<CharacterController>();
        audio = this.GetComponent<AudioSource>();
        skillIcon = FindObjectOfType<SkillList>();

        InitSkill(charName);
    }

    void Update()
    {
        CheckHP();

        if(!test)
        {
            CharacterMove();
        }
        else
        {
            Vector3 direc;

            if (Input.GetKey(KeyCode.D))
            {
                //transform.Translate(Time.deltaTime * speed, 0, 0);
                direc = transform.right;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                //transform.Translate(-Time.deltaTime * speed, 0, 0);
                direc = -transform.right;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                //transform.Translate(0, 0, Time.deltaTime * speed);
                direc = transform.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //transform.Translate(0, 0, -Time.deltaTime * speed);
                direc = -transform.forward;
            }
            else
            {
                direc = Vector3.zero;
            }

            collider.SimpleMove(direc * speed);
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

        //Status
        
    }

    private void CharacterMove()
    {
        collider.SimpleMove(transform.forward * speed * dir);
    }
    
    public void ChangeDir(int dir)
    {
        this.dir = dir;
    }

    public void HitEffect(Vector3 hitPos)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform);
        arrow.GetComponent<HitArrow>().target = hitPos;
    }

    public void GetDamage(float atk)
    {
        audio.clip = hitsound;
        audio.Play();
        hp = hp - atk;
        ui.PlayerHpBar();
    }
    public void CheckHP()
    {
        if (hp <= 0)
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

    private void InitSkill(string name)
    {
        switch(name)
        {
            case "Fire":
                GetSkill("Ball");
                break;

            case "Earth":
                GetSkill("KnockBack");
                break;
        }
    }

    public void DeleteSkill(string type)
    {
        switch (type)
        {
            case "Ball":
                ownSkill.Remove(type);
                ballLV = 0;
                skill_Ball.SetActive(false);
                break;

            case "KnockBack":
                ownSkill.Remove(type);
                knockbackLV = 0;
                skill_KnockBack.SetActive(false);
                break;

            case "Taunt":
                ownSkill.Remove(type);
                tauntLV = 0;
                skill_Taunt.SetActive(false);
                break;

            case "Nautilus":
                ownSkill.Remove(type);
                nautilusLV = 0;
                skill_Nautilus.SetActive(false);
                break;

            case "Virus":
                ownSkill.Remove(type);
                virusLV = 0;
                skill_Virus.SetActive(false);
                break;
        }
    }

    public void GetSkill(string type)
    {
        if (!ownSkill.Contains(type) && ownSkill.Count == 3)
        {
            skillChangeUI.SetActive(true);
        }

        switch (type)
        {
            case "Ball":
                ballLV++;
                if (ballLV == 1)
                {
                    ownSkill.Add(type);
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
                    ownSkill.Add(type);
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
                    ownSkill.Add(type);
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
                    ownSkill.Add(type);
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
                    ownSkill.Add(type);
                    skill_Virus.SetActive(true);
                    skill_Virus.GetComponent<PoisonGenerator>().UpdateLV(virusLV);
                }
                else
                {
                    skill_Virus.GetComponent<PoisonGenerator>().UpdateLV(virusLV);
                }
                break;
        }

        if(ownSkill.Count <= 3)
        {
            skillIcon.BGAni(ownSkill.IndexOf(type));
        }
        
    }

    public int GetSkillLV(string type)
    {
        switch (type)
        {
            case "Ball":
                return ballLV;

            case "KnockBack":
                return knockbackLV;

            case "Taunt":
                return tauntLV;

            case "Nautilus":
                return nautilusLV;

            case "Virus":
                return virusLV;

            default:
                return 0;
        }
    }
    
}
