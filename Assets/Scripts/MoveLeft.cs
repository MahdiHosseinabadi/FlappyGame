using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    void Update()
    {
        transform.position += transform.right * -2 * Time.deltaTime;
        Destroy(gameObject, 6);
    }
}
