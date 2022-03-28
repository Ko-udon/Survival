using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    private bool isAttack;
    private PlayerController player;

    public float damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();   
    }

    
    void Update()
    {
        
    }

    public void AttackAble()
    {
        isAttack = true;
    }

    public void AttackUnable()
    {
        isAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isAttack)
        {
            if(other.tag == "Player")
            {
                player.GetDamage(damage);
                isAttack = false;
            }
        }
    }
}
