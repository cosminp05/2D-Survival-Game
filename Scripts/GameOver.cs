using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ScoreManager scoreManager;  // Referință la ScoreManager
    public BackgroundMusic backgroundMusic;  // Referință la BackgroundMusic
    public List<MonoBehaviour> scriptsToDisable;  // Lista de scripturi de dezactivat
    public ParticleSystem particles;  // Referință la particule

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null && !scoreManager.isGameOver)
        {
            gameOverPanel.SetActive(true);
            scoreManager.isGameOver = true;

            // Oprim toate scripturile din lista
            foreach (var script in scriptsToDisable)
            {
                script.enabled = false;
            }

            if (particles != null)
            {
                particles.Stop();  // Oprim particulele
            }

            if (backgroundMusic != null)
            {
                backgroundMusic.StopMusic();  // Oprim muzica de fundal
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Pornim muzica de fundal
        if (backgroundMusic != null)
        {
            backgroundMusic.PlayMusic();
        }
    }
}
