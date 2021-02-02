using UnityEngine;
using System.Collections;

public class SpawnerEnemys : MonoBehaviour {

    public GameObject[] Enemys;
    public float timeSpawm;
    public float lastTime;
    public int localIndex;

    public GameObject beginSpawnerLocal;
    public GameObject endSpawnerLocal;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameController.Instance.StartGame)
        {
            SpawnEnemys();
        }

	}

    void SpawnEnemys()
    {
        if (Time.time > lastTime + Random.Range(8, timeSpawm))
        {
            transform.position = new Vector3(Random.Range(beginSpawnerLocal.transform.position.x, endSpawnerLocal.transform.position.x), transform.position.y, transform.position.z) ;

            Instantiate(Enemys[Random.Range(0,Enemys.Length)], transform.position, Quaternion.identity);


            lastTime = Time.time;
        }
    }
}
