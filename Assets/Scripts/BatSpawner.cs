using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject batSpawner;
    public GameObject bat;

    List<GameObject> bats;
    List<GameObject> spawnLocations;
    float lastChecked;
    
    void Start()
    {
        bats = new List<GameObject>();
        spawnLocations = new List<GameObject>();

        int i = 0;
        foreach(Transform spawnLocation in batSpawner.transform)
        {
            spawnLocations.Add(spawnLocation.gameObject);
        }

        lastChecked = Time.time;
        for(i = 0; i < spawnLocations.Count; ++i)
        {
            bats.Add(Instantiate(bat, spawnLocations[i].transform.position, Quaternion.identity));
        }
    }

    void Update()
    {
        if(lastChecked + 5f < Time.time)
        {
            Debug.Log("Got here");
            for(int i = 0; i < bats.Count; ++i)
            {
                if(bats[i] == null)
                {
                    Debug.Log("And here");
                    StartCoroutine(CreateBat(i));
                }
            }
            lastChecked = Time.time;
        }
    }

    IEnumerator CreateBat(int i)
    {
        GameObject newBat = Instantiate(bat, spawnLocations[i].transform.position, Quaternion.identity);
        bats[i] = newBat;
        newBat.SetActive(false);
        yield return new WaitForSeconds(25);
        newBat.SetActive(true);
    }
}
