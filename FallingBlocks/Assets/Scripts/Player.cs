using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10;
    float screenHalfWidth;
    public event System.Action OnPlayerDeath;
    

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        Vector2 moveAmount = Vector2.right* velocity * Time.deltaTime;
        transform.Translate(moveAmount);

        if (transform.position.x < -screenHalfWidth)
            transform.position = new Vector2(screenHalfWidth, transform.position.y);

        if (transform.position.x > screenHalfWidth)
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Bomb")
        {
            if (OnPlayerDeath != null)
                OnPlayerDeath();

            Destroy(gameObject);
        }
    }
}