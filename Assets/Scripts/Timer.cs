using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer main;
    public float timeLeft;
    private float timePassed = 0;
    private int mins;
    private int secs;
    public bool isPaused;
    public int enemyNumber;
    private float baseTime;
    private int countTime = 1;
    public Rigidbody2D ball;
    Vector2 sp = new Vector2(0f, 2.1f);
    public GameObject timeZero;
    public Text score;

    // Start is called before the first frame update

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        mins = Mathf.FloorToInt(timeLeft / 60);
        secs = Mathf.FloorToInt(timeLeft % 60);
        GetComponent<Text>().text = mins.ToString("00") + ":" + secs.ToString("00");
        StartCoroutine(CountDown());
        baseTime = timeLeft / enemyNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        isPaused = false;
        while (!isPaused)
        {
            yield return new WaitForSeconds(1);
            timeLeft -= 1;
            timePassed++;
            if(timePassed > baseTime * countTime)
            {
                countTime++;
                SpawnEnemy();
            }
            mins = Mathf.FloorToInt(timeLeft / 60);
            secs = Mathf.FloorToInt(timeLeft % 60);
            GetComponent<Text>().text = mins.ToString("00") + ":" + secs.ToString("00");
            if(timeLeft < 1)
            {
                Time.timeScale = 0;
                score.text = "Your score is : " + PlayerMovement.main.money;
                timeZero.SetActive(true);
            }
        }
    }

    void SpawnEnemy()
    {
        float x = Random.Range(-17f, 11f);
        sp = new Vector2(x, -5f);
        Debug.Log("spawn");
        GameObject go = Instantiate(ball, sp, transform.rotation).gameObject;
    }
}
