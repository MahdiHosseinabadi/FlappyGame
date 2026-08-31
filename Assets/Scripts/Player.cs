using UnityEngine;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float JumpH;

    public Animator Flapping;
    public Animator Death;
    public bool GameOver;

    public GameObject GameOverScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
            rb.AddForce(Vector2.up * JumpH, ForceMode2D.Impulse);
            Flapping.Play("PlayerFlap");
        }

        if (GameOver)
        {
            GameOverScene.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Jumpinp()
    {
        if (!GameOver)
        {
            rb.AddForce(Vector2.up * JumpH, ForceMode2D.Impulse);
            Flapping.Play("PlayerFlap");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Death.Play("PlayerDeath");
            GameOver = true;
        }
    }
}
