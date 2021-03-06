using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //wander if can't see player
    //if enemy see's player, will pursue
    //if player throws grenade enemy will pursue grenade


    private Enemy bot;
    private Vector3 grenadePos;
    private Weapon grenadeThrown;
    


    // Start is called before the first frame update
    void Start()
    {
        grenadeThrown = GameObject.Find("Player").GetComponent<Weapon>();
        
        bot = GetComponent<Enemy>();
        Weapon.GrenadeThrownDown += GrenadeReady;
        
    }

    void GrenadeReady(Vector3 pos)
    {
        grenadePos = grenadeThrown.grenadePos;

    }

    // Update is called once per frame
    void Update()
    {   
        if (grenadeThrown.grenadeThrown)
        {
            bot.Seek(grenadePos);
        }
        else
        {

            
            if (bot.CanSeeTarget())
            {
                
                bot.Pursue();
            }
            else
            {
               
                bot.Pursue();
            }
        }
    }
}