using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
    public GameObject tauntPrefab;
    private GameObject player;

    public float coolTime;
    private float duration;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolTime = 5.0f;
        duration = 2.5f;
    }

    
    void Update()
    {
        coolTime -= Time.deltaTime;

        if(coolTime < 0)
        {
            GameObject turret = Instantiate(tauntPrefab, new Vector3(player.transform.position.x, -0.5f, player.transform.position.z), player.transform.rotation) as GameObject;
            turret.GetComponent<Turret>().time = duration;
            coolTime = 5.0f;
        }
    }

    public void UpdateLV(int level)
    {
        duration = 2.5f * level;
    }
}
