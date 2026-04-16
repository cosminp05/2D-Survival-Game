
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score;
    public bool isGameOver = false;  // Variabilă pentru a urmări dacă jocul s-a terminat
    public Player player;  // Referință la scriptul Player

    void Update()
    {
        if (!isGameOver && player.gameStarted)  // Verificăm dacă jocul a început și nu s-a terminat
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)  // Verificăm dacă există un player
            {
                score += 1 * Time.deltaTime;
                scoreText.text = ((int)score).ToString();
            }
            else
            {
                isGameOver = true;
            }
        }
    }
}
