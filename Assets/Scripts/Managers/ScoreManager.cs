using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int animalScore;
    public Text animalScoreText;
    //[SerializeField]
    //public Text animalScoreText;

    //public int score;
    private void Start()
    {
        animalScore = 0;
    }
    private void Update()
    {
        animalScoreText.text = "" + animalScore;
    }
    //public int Score
    //{
    //    get { return score; }
    //    set
    //    {
    //        score = value;

    //    }
    //}
}
