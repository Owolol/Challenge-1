using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float speed;
    public Text CountText;
    public Text ScoreText;
    public Text WinText;
    public Text LivesText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;



    void Start ()
    {
                rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        score = 0;
        SetScoreText();
        lives = 3;
        SetLivesText();
        WinText.text = "";
                    }

    void FixedUpdate ()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
            }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score + 1;
            SetScoreText();
        }




        if (other.gameObject.CompareTag("Enemy"))

        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
            lives = lives - 1;
            SetLivesText();
        }

        if (count == 12) 
        {
             transform.position = new Vector3(0, 1, 32); 
        }
    }

    void SetCountText ()
    {
        CountText.text = "Squares Collected: " + count.ToString ();
        
    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            LivesText.text = "GAME OVER";
        }
        if (lives <= 0)
        
        {
            Destroy(gameObject, 1);
        }
        
    }

    void SetScoreText()
    {
        
        ScoreText.text = "Score: " + score.ToString ();
                
        if (score >= 24)
        {
            WinText.text = "Nice Dodging Skills! You Win!";
        }
    }

   
}

  
    

