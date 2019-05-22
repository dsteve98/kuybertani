using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int[] sellValue;
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
            for(int a = 0; a < 7; a++)
            {
                PlayerMovement.main.money += PlayerMovement.main.harvest[a] * sellValue[a];
                PlayerMovement.main.harvest[a] = 0;
            }
        }
    }
}
