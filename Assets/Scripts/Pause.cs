using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            Debug.Log(count);
            count++;
            count %= 2;
            if (count == 1) pausemenu.SetActive(false);
            else pausemenu.SetActive(true);
            Time.timeScale = count;
        }
    }
}
