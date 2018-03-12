using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour {

    public GameObject tower;
    public GameObject lowPlatform;
    public GameObject stairs;
    public GameObject tree;

    private int maxTowerSpawn;
    private int maxLowPlatformSpawn;
    private int maxStairsSpawn;
    private int maxTreeSpawn;
    private int towerSpawn = 0;
    private int lowPlatformSpawn = 0;
    private int stairsSpawn = 0;
    private int treeSpawn = 0;

    /// <summary>
    /// Very BASE world Generation Method
    /// Needs cleanup 
    /// Needs way to prevent overlap
    /// Needs way to easily add new types of objects
    /// Needs to be less memory hungry
    /// </summary>
    void Awake () {

        int maxRange = 120;
        int minRange = maxRange * -1;
        Vector3 randomVector;
        maxTowerSpawn = Random.Range(4, 9);
        maxLowPlatformSpawn = Random.Range(5, 10);
        maxStairsSpawn = Random.Range(4, 9);
        maxTreeSpawn = Random.Range(8, 18);
        
        while (towerSpawn < maxTowerSpawn)
        {
            randomVector = new Vector3(Random.Range(minRange,maxRange), 5, Random.Range(minRange,maxRange));
            Instantiate(tower,randomVector,Quaternion.Euler(0, Random.Range(0, 359),0));
            towerSpawn++;
        }

        while (lowPlatformSpawn < maxLowPlatformSpawn)
        {
            randomVector = new Vector3(Random.Range(minRange, maxRange), 1.5f, Random.Range(minRange, maxRange));
            Instantiate(lowPlatform, randomVector, Quaternion.Euler(0, Random.Range(0, 359), 0));
            lowPlatformSpawn++;
        }

        while (stairsSpawn < maxStairsSpawn)
        {
            randomVector = new Vector3(Random.Range(minRange, maxRange), 0.3f, Random.Range(minRange, maxRange));
            Instantiate(stairs, randomVector, Quaternion.Euler(0, Random.Range(0, 359), 0));
            stairsSpawn++;
        }

        while (treeSpawn < maxTreeSpawn)
        {
            randomVector = new Vector3(Random.Range(minRange, maxRange), 0.5f, Random.Range(minRange, maxRange));
            Instantiate(tree, randomVector, Quaternion.Euler(0, Random.Range(0, 359), 0));
            treeSpawn++;
        }
    }	
}
