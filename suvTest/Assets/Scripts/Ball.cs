using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float damage;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        damage = 20;
    }

    void Update()
    {
        transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Hp -= damage;
            StartCoroutine(other.gameObject.GetComponent<EnemyController>().Stiff(1.0f));
        }
    }
}
