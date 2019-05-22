using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public int seedtype;
    public int seedcost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hitbox"))
        {
            if(PlayerMovement.main.money >= seedcost)
            {
                PlayerMovement.main.money -= seedcost;
                PlayerMovement.main.seed[seedtype] += 1;
            }
        }
    }
}
