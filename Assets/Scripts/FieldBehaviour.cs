using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    public Sprite[] plantSprites;
    public int state = 0;

    void Awake()
    {
        
    }

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
                GetComponent<SpriteRenderer>().sprite = plantSprites[0];
                //Debug.Log(plantSprites.Length);
                //Debug.Log(state);
            }
        }
    }
}
