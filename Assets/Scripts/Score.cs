using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private TextMeshProUGUI _Score;


    private void Update()
    {
        _Score.text = "Score: " + score.ToString() + " / " + NextScene.maxS;
    }


}
