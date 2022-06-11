using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Getskill : MonoBehaviour
{
    public string skillType;
    private GameObject player;
    AudioSource audio;
    public Image img;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audio = this.GetComponent<AudioSource>();
        img = this.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 target = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        transform.LookAt(target);*/

        transform.rotation = player.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Play();
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
            other.GetComponent<PlayerController>().GetSkill(skillType);
            Invoke("Delay", 0.2f);
            //Destroy(this.gameObject);
        }
    }

    private void Delay()
    {

        Destroy(this.gameObject);
    }
}
