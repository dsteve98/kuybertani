using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutor;
    public Image tutorImage;
    [SerializeField]
    private Sprite[] tutorSprites;
    private int tutorialCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            tutor.SetActive(false);
        }
        else if (Input.GetButtonDown("Right") && tutorialCount < 5)
        {
            tutorialCount++;
        }
        else if (Input.GetButtonDown("Left") && tutorialCount > 0)
        {
            tutorialCount--;
        }
        tutorImage.sprite = tutorSprites[tutorialCount];  
    }
}
