using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
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
        
        if(other.CompareTag("hitbox") && PlayerMovement.main.currentEquip == "watercan")
        {
            PlayerMovement.main.watercount = 12;
        }
    }
}
