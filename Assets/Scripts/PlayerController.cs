using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
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
            GameManager.score++;
            setCountText();
        }

        if (other.gameObject.CompareTag("Killer"))
        {
            GameOver();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                gameObject.SetActive(false);
                winText.text = "!!!YOU WIN!!! Score: " + GameManager.score.ToString();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + GameManager.score.ToString();
    }

    void GameOver()
    {
        winText.text = "!!!YOU DIE!!!";
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
