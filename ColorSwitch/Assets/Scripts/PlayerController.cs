using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Color pink = new Color(0.99f, 0f, 0.5f);
    private Color yellow = new Color(0.95f, 0.85f, 0.04f);
    private Color blue = new Color(0.22f, 0.87f, 0.95f);
    private Color purple = new Color(0.45f, 0.13f, 0.85f);

    private bool isStarted = false;
    private bool isGameOver = false;

    private string currentColor;

    private int score = 0;

    private Rigidbody2D rb;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text tapToPlayText;
    [SerializeField]
    private Text tapToRetryText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tapToRetryText.enabled = false;
    }

    private void Update()
    {
        if(!isStarted && !isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
        }
        else if (isStarted && !isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(0f, 4f);
            }
        }
        else if(isGameOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }            
        }

        if(transform.position.y < Camera.main.transform.position.y - 5)
        {
            GameOver();
        }
    }

    private void StartGame()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector2(0f, 4f);
        tapToPlayText.enabled = false;
        isStarted = true;
    }

    private void ChangeColor()
    {
        int temp = Random.Range(0, 4);
        switch (temp)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = pink;
                currentColor = "Pink";
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = yellow;
                currentColor = "Yellow";
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = blue;
                currentColor = "Blue";
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = purple;
                currentColor = "Purple";
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "change_color")
        {
            ChangeColor();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Star")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag != currentColor)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        tapToRetryText.enabled = true;
        isGameOver = true;
    }
}
