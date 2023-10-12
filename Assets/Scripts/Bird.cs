using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    int Score;
    public TMP_Text ScoreText;
    public float rotatePower;
    public float jumpSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
            transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    void Die()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
