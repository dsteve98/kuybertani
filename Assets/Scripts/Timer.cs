using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer main;
    public float timeLeft;
    private int mins;
    private int secs;
    public bool isPaused;

    // Start is called before the first frame update

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        mins = Mathf.FloorToInt(timeLeft / 60);
        secs = Mathf.FloorToInt(timeLeft % 60);
        GetComponent<UnityEngine.UI.Text>().text = mins.ToString("00") + ":" + secs.ToString("00");
        StartCoroutine(CountDown());
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
            mins = Mathf.FloorToInt(timeLeft / 60);
            secs = Mathf.FloorToInt(timeLeft % 60);
            GetComponent<UnityEngine.UI.Text>().text = mins.ToString("00") + ":" + secs.ToString("00");
        }
    }
}
