using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public Player player;  // Referință la scriptul Player

    void Update()
    {
        if (player.gameStarted)  // Verificăm dacă jocul a început
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
        }
    }
}
