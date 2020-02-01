using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public ScoreCube[] player1ScoreBoxes;
    public ScoreCube[] player2ScoreBoxes;

    public float player1Score = 0;
    public float player2Score = 0;

    private void Start()
    {
        Instance = this;
    }

    public float GetPlayerScore(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                return player1Score;
            case 2:
                return player2Score;
            default:
                return 1;
        }
    }

    void Update()
    {
        int player1Boxes = 0;
        float player1RawScore = 0;

        int player2Boxes = 0;
        float player2RawScore = 0;
        
        foreach (ScoreCube box in player1ScoreBoxes)
        {
            player1Boxes++;
            player1RawScore += box.scoreNormalized;
            player1Score = player1RawScore / (float) player1Boxes;
        }
        
        foreach (ScoreCube box in player2ScoreBoxes)
        {
            player2Boxes++;
            player2RawScore += box.scoreNormalized;
            player2Score = player2RawScore / (float) player2Boxes;
        }
    }
}
