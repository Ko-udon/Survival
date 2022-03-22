using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitArrow : MonoBehaviour
{
    public Vector3 target;
    public GameObject player;
    private Image effect;

    public float appearTime;
    private float time;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        effect = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        appearTime = 1.5f;
        time = appearTime;
    }


    void Update()
    {
        Vector3 dir = new Vector3(target.x, transform.position.y, target.z);

        transform.LookAt(dir);

        time -= Time.deltaTime;

        effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, time / appearTime);

        if(time < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
