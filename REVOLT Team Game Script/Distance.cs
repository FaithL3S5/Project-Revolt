using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Text scoreText;
    public Text scoreDisp;
    public Text hiScoreDisp;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    [SerializeField]
    public GameObject NewBest;

    [SerializeField]
    private Controller player;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("HighScore") != null)
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            //time counting score
            //scoreCount += pointsPerSecond * Time.deltaTime;

            //x axis counting score
            scoreCount = player.GetPosition().x / 10;
        }

        if (scoreCount > hiScoreCount)
        {
            NewBest.SetActive(true);
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);

        }

        scoreText.text = "Distance :" + Mathf.Round(scoreCount) + "M";
        scoreDisp.text = "Distance         :" + Mathf.Round(scoreCount) + "M";
        hiScoreDisp.text = "Best Distance :" + Mathf.Round(hiScoreCount) + "M";
    }
}
