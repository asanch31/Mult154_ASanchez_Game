using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDurability : MonoBehaviour
{
    //durabilty of barriers
    private float durability = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if durabilty is zero destroy object
        
        if(durability <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //lower durabilty of object if enemy/boss
        if (other.gameObject.CompareTag("Enemy"))

        {
            durability = durability - 1;
        }
        if (other.gameObject.CompareTag("Boss"))

        {
            durability = durability - 2;
        }

    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.CompareTag("Enemy"))

        {
            durability = durability - .1f;
            
        }
        if (other.gameObject.CompareTag("Boss"))

        {
            durability = durability - .2f;

        }
    }
}
