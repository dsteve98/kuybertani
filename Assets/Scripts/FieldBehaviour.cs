using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{

    [SerializeField]
    private Sprite[] plantSprites;
    private int state = 0;
    private int waterLevel = 6;
    private int planttype;
    private int progresslimit = 2;
    private int progress = 0;
    private bool needWater;
    private float currCountdownValue = 0;
    public float timeperstep;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waterLevel > 4)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (waterLevel > 2)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            needWater = true;
        }
        else if (waterLevel > 0)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            waterLevel = 6;
            currCountdownValue = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = plantSprites[42];
            state = 0;
            gameObject.tag = "field";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hitbox"))
        {
            if (state == 0)
            {
                if (PlayerMovement.main.currentEquip == "tomatoseed" && PlayerMovement.main.seed[0] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[0];
                    planttype = 0;
                    state = 1;
                    //Debug.Log("plant tomato");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
                else if (PlayerMovement.main.currentEquip == "potatoseed" && PlayerMovement.main.seed[1] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[1];
                    planttype = 1;
                    state = 1;
                    //Debug.Log("plant potato");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
                else if (PlayerMovement.main.currentEquip == "carrotseed" && PlayerMovement.main.seed[2] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[2];
                    planttype = 2;
                    state = 1;
                    //Debug.Log("plant carrot");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
                else if (PlayerMovement.main.currentEquip == "broccoliseed" && PlayerMovement.main.seed[3] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[3];
                    planttype = 3;
                    state = 1;
                    //Debug.Log("plant broccoli");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
                else if (PlayerMovement.main.currentEquip == "strawberryseed" && PlayerMovement.main.seed[4] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[4];
                    planttype = 4;
                    state = 1;
                    //Debug.Log("plant strawberry");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
                else if (PlayerMovement.main.currentEquip == "cucumberseed" && PlayerMovement.main.seed[5] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[5];
                    planttype = 5;
                    state = 1;
                    //Debug.Log("plant cucumber");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
                else if (PlayerMovement.main.currentEquip == "cornseed" && PlayerMovement.main.seed[6] != 0)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[6];
                    planttype = 6;
                    state = 1;
                    //Debug.Log("plant corn");
                    StartCoroutine(StartCountdown());
                    gameObject.tag = "plant";
                }
            }
            if (PlayerMovement.main.currentEquip == "watercan" && PlayerMovement.main.watercount > 0 && needWater == true)
            {
                waterLevel = 6;
                needWater = false;
                progress += 1;
                currCountdownValue = 0;
                if (progress == progresslimit && state < 4)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[state * 7 + planttype];
                    progress = 0;
                    state += 1;
                }
            }
            else if (PlayerMovement.main.currentEquip == "barehand" && state == 4)
            {
                if (planttype == 0 || planttype == 4 || planttype == 5 || planttype == 6)
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[state * 7 + planttype];
                    state = 2;
                    StartCoroutine(StartCountdown());
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = plantSprites[42];
                    state = 0;
                }
                PlayerMovement.main.harvest[planttype] += 1;
            }
        }
        else if (other.CompareTag("enemy"))
        {
            Debug.Log("enemy in range");
            waterLevel = 6;
            currCountdownValue = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = plantSprites[42];
            state = 0;
            gameObject.tag = "field";
        }
        else Debug.Log(other.tag);
    }

    private IEnumerator StartCountdown()
    {
        while (true)
        {
            //Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue++;
            if (state == 0 || state == 4)
            {
                waterLevel = 6;
                currCountdownValue = 0;
                break;
            }
            if (currCountdownValue >= timeperstep)
            {
                waterLevel--;
                currCountdownValue = 0;
            }
        }
    }
}
