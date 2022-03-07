using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController player;
    public float damage = 10.0f;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            player.GetDamage(damage);
            Destroy(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
    }
}
