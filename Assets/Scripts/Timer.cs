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
    public GameObject prefab;
    public int enemyNumber;
    private float baseTime;
    private int countTime = 1;

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
                float x = Random.Range(-17f, 11f);
                Transform pos = transform;
                pos.position = transform.position - transform.position;
                pos.position += new Vector3(x, -5f, 0);
                Instantiate(prefab, pos);
                countTime++;
            }
            mins = Mathf.FloorToInt(timeLeft / 60);
            secs = Mathf.FloorToInt(timeLeft % 60);
            GetComponent<Text>().text = mins.ToString("00") + ":" + secs.ToString("00");
        }
    }
}
