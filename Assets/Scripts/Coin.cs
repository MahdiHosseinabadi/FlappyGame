using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            ScoreManager.instance.AddScore();

            AudioManager.instance.Play(SoundType.Coin);

            Destroy(gameObject);
        }
    }
}