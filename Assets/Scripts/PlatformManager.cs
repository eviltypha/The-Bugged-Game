using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public float zpos = 0;
    public float PlatformLength = 30;
    public Transform player;
    private List<GameObject> ActivePlatforms = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                SpawnPlatform(0);
            }
            else
            {
                SpawnPlatform(Random.Range(0, PlatformPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z - 50 > zpos-(5*PlatformLength))
        {
            SpawnPlatform(Random.Range(0, PlatformPrefabs.Length));
            DeletePlatforms();
        }
    }
    public void SpawnPlatform(int PlatformIndex)
    {
        GameObject go = Instantiate(PlatformPrefabs[PlatformIndex], transform.forward * zpos, transform.rotation);
        ActivePlatforms.Add(go);
        zpos += PlatformLength;
    }
    private void DeletePlatforms()
    {
        Destroy(ActivePlatforms[0]);
        ActivePlatforms.RemoveAt(0);
    }
}
