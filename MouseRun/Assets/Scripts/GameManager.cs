using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<GameObject> Roads = new List<GameObject>();

    [SerializeField] Transform playerPrefab;
    [SerializeField] Transform carSpawn;

    float previousPlayerZ;
    float roadLenght = 3.17f;

    int count = 5;
    // Start is called before the first frame update
    void Start()
    {
        //�lk zemini �ret
        Instantiate(Roads[0],transform.position,transform.rotation);
        
        for (int i = 0; i < count; i++)
        {
            CreateRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPrefab.position.z > roadLenght - 3.17f * count)
        {
            CreateRoad();
        }
    }

    private void FixedUpdate()
    {
        //Oyuncunun z pozisyonundaki de�i�imini  hesapla
        float deltaZ = playerPrefab.position.z - previousPlayerZ;

        //Car spawner Z eksenini yukar�daki de�i�im kadar artt�r
        carSpawn.position += new Vector3(0,0,deltaZ);

        //Bir sonraki kare i�in �nceki z pozisyonunu gencelle
        previousPlayerZ = playerPrefab.position.z;
    }

    void CreateRoad()
    {
        Instantiate(Roads[Random.Range(0, Roads.Count)], transform.forward * roadLenght, transform.rotation);
        roadLenght += 3.17f;
    }
}
