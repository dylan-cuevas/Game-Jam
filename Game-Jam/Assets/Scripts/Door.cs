using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LevelLoader l;

    public int count;

    public GameObject[] enemies;



   public void addCount()
    {
        count += 1;
    }
    
   void OnTriggerEnter2D(Collider2D other)
    {
        if (count == 4)
        {
            if (other.tag == "Player")
            {
                l.transitionHelp();
            }

        }

    }
}
