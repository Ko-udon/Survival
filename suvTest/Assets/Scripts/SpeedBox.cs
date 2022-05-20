using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBox : MonoBehaviour
{
    public float speedAmount;
    public float rotateSpeed;
    PlayerController player;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.speed += speedAmount;

            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        RotateItem();
    }
    void RotateItem()
    {
        this.transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime));
    }
}
