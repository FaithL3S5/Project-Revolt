using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
//using UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 500f;
    //private Player player;

    [SerializeField] 
    private Transform levelPart_Start;

    [SerializeField] 
    private List<Transform> levelPartList;

    [SerializeField] 
    private Controller player;


    private Vector3 lastEndPosition;
   
    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
 
        int startingSpawnLevelParts = 1;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
        

    }

    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        { //spawn another leVel part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[UnityEngine.Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform lastLevelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return lastLevelPartTransform;
    }

    /*
     //incomplete implementation(preventing crash)
    public void DestroyLevelParts()
    {
        levelParts = GameObject.FindGameObjectsWithTag("levelPart");

        for (var i = 0; i < levelParts.Length; i++)
        {
            Destroy(levelParts[i]);
        }

        lastEndPosition = startPosition.transform.position;

    }
    */
}
