using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public bool gameStarted = false;  // Variabilă pentru a verifica dacă jocul a început
    public ParticleSystem particles;  // Referință la particule

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (particles != null)
        {
            particles.Stop();  // Oprim particulele la start
        }
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");

        if (!gameStarted && directionY != 0)
        {
            gameStarted = true;  // Inițializăm jocul la prima mișcare a player-ului
            if (particles != null)
            {
                particles.Play();  // Pornim particulele când jocul începe
            }
        }

        if (gameStarted)
        {
            playerDirection = new Vector2(0, directionY).normalized;
        }
    }

    void FixedUpdate()
    {
        if (gameStarted)
        {
            rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);  // Folosim linearVelocity pentru a controla mișcarea player-ului
        }
        else
        {
            rb.linearVelocity = Vector2.zero;  // Oprim mișcarea înainte ca jocul să înceapă
        }
    }
}
