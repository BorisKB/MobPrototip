using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScore : MonoBehaviour
{
    [SerializeField] private Text text;

    private int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore() 
    {
        currentScore++;
        text.text = "Score: " + currentScore.ToString();
    }

    public void SetNewScore()
    {
        currentScore= 0;
        text.text = "Score: " + currentScore.ToString();
    }
}
