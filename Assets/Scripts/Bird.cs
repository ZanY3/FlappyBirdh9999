using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public string[] SkinList;
    public string[] BackList;
    int Score;
    public TMP_Text ScoreText;
    public float rotatePower;
    public float jumpSpeed;
    Rigidbody2D rb;
    public GameObject endScreen;

    public GameObject YellowSkin;
    public GameObject RedSkin;
    public GameObject BlueSkin;

    public GameObject Night;
    public GameObject Day;

    public float speed;
    public GameObject Tutorial;

    public AudioClip scoreSound;
    public AudioClip punchSound;
    public AudioClip Flap;

    public GameObject Flash;

    public AudioSource source;
    void Start()
    {
        if(BackList.Length > 0)
        {
            int randomIndex = Random.Range(0, BackList.Length);
            string randomBg = BackList[randomIndex];
            if (randomBg == "Night")
            {
                Night.SetActive(true);
                Day.SetActive(false);
            }
            if (randomBg == "Day")
            {
                Night.SetActive(false);
                Day.SetActive(true);


            }
        }

        if(SkinList.Length > 0)
        {
            int randomInx = Random.Range(0, SkinList.Length);
            string randomSkin = SkinList[randomInx];
            if(randomSkin == "YellowSkin")
            {
                YellowSkin.SetActive(true);
                RedSkin.SetActive(false);
                BlueSkin.SetActive(false);

            }
            if (randomSkin == "BlueSkin")
            {
                YellowSkin.SetActive(false);
                RedSkin.SetActive(false);
                BlueSkin.SetActive(true);

            }
            if (randomSkin == "RedSkin")
            {
                YellowSkin.SetActive(false);
                RedSkin.SetActive(true);
                BlueSkin.SetActive(false);

            }

        }

        Pipe.speed = speed;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            source.PlayOneShot(Flap);
            Pipe.speed = 5.5f;
            rb.gravityScale = 3;
            Tutorial.SetActive(false);
            ScoreText.gameObject.SetActive(true);
            rb.velocity = Vector2.up * jumpSpeed;
        }
            transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        source.PlayOneShot(punchSound);
        Die();
    }
    void Die()
    {
        jumpSpeed = 0;
        Pipe.speed = 0;
        rb.velocity = Vector2.zero;
        //GetComponentInChildren<Animator>().enabled = false;
        Invoke("ShowMenu", 1f);
        PlayerPrefs.SetInt("Score", Score);
        Flash.SetActive(true);

    }
        void ShowMenu()
        {
            print("The end");
            endScreen.SetActive(true);
            ScoreText.gameObject.SetActive(false);
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        source.PlayOneShot(scoreSound);
        Score++;
        ScoreText.text = Score.ToString();
    }
}
