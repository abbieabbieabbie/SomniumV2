using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public List<Sprite> SpriteList;
    public GameObject enemy;
    public Transform parent;
    public GameObject player;
    [SerializeField]
    private float respawnTime;
    int attempt = 1;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateEnemy(0, new Vector3(0,0.3f,5));
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnTime <= 0)
        {
            InstantiateEnemy(0, new Vector3(Random.Range(-19f,19f),0,Random.Range(-19f,19f)));
            respawnTime += Random.Range(20f,35f);
        } else
        {
            respawnTime -= Time.deltaTime;
        }
    }

    void InstantiateEnemy(int type, Vector3 spawnPosition)
    {
        int id = type;
        if (Vector3.Distance(transform.position, player.transform.position) < 7f)
        {
            if (attempt <= 100)
            {
                InstantiateEnemy(0, new Vector3(Random.Range(-19f,19f),0,Random.Range(-19f,19f)));
                attempt += 1;
            } else
            {
                respawnTime = 2f;
                attempt = 1;
            }
        } else
        {
            GameObject clone = Instantiate(enemy, parent);
            clone.transform.position = spawnPosition;
            clone.name = (string)SpriteList[type].name;
        }
        
    }
    public void GameOver()
    {
        Destroy(gameObject);
    }
}
