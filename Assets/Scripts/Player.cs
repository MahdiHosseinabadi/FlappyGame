using UnityEngine;


public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float JumpH;

    public Animator Flapping;
    public Animator Death;
    public bool GameOver;

    public GameObject GameOverScene;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
            rigidbody.AddForce(Vector2.up * JumpH, ForceMode2D.Impulse);
            Flapping.Play("PlayerFlap");
            AudioManager.instance.Play(SoundType.PlayerJump);
        }

        if (GameOver)
        {
            GameOverScene.SetActive(true);
            AudioManager.instance.Play(SoundType.GameOver);
            Time.timeScale = 0;
        }
    }

    public void Jumpinp()
    {
        if (!GameOver)
        {
            rigidbody.AddForce(Vector2.up * JumpH, ForceMode2D.Impulse);
            Flapping.Play("PlayerFlap");
            AudioManager.instance.Play(SoundType.PlayerJump);
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
