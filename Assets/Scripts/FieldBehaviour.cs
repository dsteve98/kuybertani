using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    public bool playerInteract;
    public int state = 0;

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
            if(PlayerMovement.currentEquip == "seed" && state == 0)
            {
                state = 1;
                Debug.Log(state);
            }
        }
    }
}
