using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getskill : MonoBehaviour
{
    public string skillType;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().GetSkill(skillType);
            Destroy(this.gameObject);
        }
    }
}
