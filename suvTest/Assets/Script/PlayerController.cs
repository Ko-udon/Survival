using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float hp;

    public GameObject arrowPrefab;
    public GameObject playerCharacter;


    //UI관련
    


    void Start()
    {
        
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
    }

    public void HitEffect(Vector3 hitPos)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform);
        arrow.GetComponent<HitArrow>().target = hitPos;
    }

    public void GetDamage(float atk)
    {
        hp = hp - atk;
    }
    public void CheckHP()
    {
        if (hp < 0)
        {
            //gameObject.SetActive(false);
            playerCharacter.SetActive(false);
        }
    }
}
