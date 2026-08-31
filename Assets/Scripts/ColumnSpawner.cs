using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{

    public GameObject ColumnPrefab;
    public float minY, maxY;
    float Timer;
    public float maxTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnColumn();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= maxTime)
        {
            SpawnColumn();
            Timer = 0;
        }
    }

    void SpawnColumn()
    {
        float randomYposition = Random.Range(minY, maxY);
        GameObject newColumn = Instantiate(ColumnPrefab);
        newColumn.transform.position = new Vector2(transform.position.x, randomYposition);
    }
}
