using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{

    [SerializeField]
    private Sprite[] plantSprites;
    private int state = 0;
    private int waterlevel = 4;
    private int planttype;
    private int progresslimit = 2;
    private int progress = 0;


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
            if(state == 0)
            {
                Debug.Log(PlayerMovement.main.seed[2]);
                if (PlayerMovement.main.currentEquip == "tomatoseed" && PlayerMovement.main.seed[0] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[0];
                    planttype = 0;
                    state = 1;
                    Debug.Log("plant tomato");
                }
                else if (PlayerMovement.main.currentEquip == "potatoseed" && PlayerMovement.main.seed[1] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[1];
                    planttype = 1;
                    state = 1;
                    Debug.Log("plant potato");
                }
                else if (PlayerMovement.main.currentEquip == "carrotseed" && PlayerMovement.main.seed[2] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[2];
                    planttype = 2;
                    state = 1;
                    Debug.Log("plant carrot");
                }
                else if (PlayerMovement.main.currentEquip == "broccoliseed" && PlayerMovement.main.seed[3] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[3];
                    planttype = 3;
                    state = 1;
                    Debug.Log("plant broccoli");
                }
                else if (PlayerMovement.main.currentEquip == "strawberryseed" && PlayerMovement.main.seed[4] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[4];
                    planttype = 4;
                    state = 1;
                    Debug.Log("plant strawberry");
                }
                else if (PlayerMovement.main.currentEquip == "cucumberseed" && PlayerMovement.main.seed[5] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[5];
                    planttype = 5;
                    state = 1;
                    Debug.Log("plant cucumber");
                }
                else if (PlayerMovement.main.currentEquip == "cornseed" && PlayerMovement.main.seed[6] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[6];
                    planttype = 6;
                    state = 1;
                    Debug.Log("plant corn");
                }
            }
            if(PlayerMovement.main.currentEquip == "watercan" && PlayerMovement.main.watercount > 0)
            {
                progress += 1;
                if(progress == progresslimit && state < 4)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[state*7+planttype];
                    progress = 0;
                    state += 1;
                }
            }

        }
    }
}
