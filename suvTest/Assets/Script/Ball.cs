using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Hp -= 20;
            StartCoroutine(other.gameObject.GetComponent<EnemyController>().Stiff(1.0f));
        }
    }
}
