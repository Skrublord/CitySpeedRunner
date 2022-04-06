using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 25f;
    [SerializeField] private Transform LevelPartStart;
    [SerializeField] private List<Transform> LevelSectorList;
    //[SerializeField] private Transform LevelSector3;
    [SerializeField] private Transform player1;

    private Vector3 lastEndPostion;
    
    private void Awake()
    {
        lastEndPostion = LevelPartStart.Find("EndPosition").position;
        SpawnLevelPart();
    }

    private void Update()
    {
        if(Vector3.Distance(player1.position, lastEndPostion) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //Spawn New Level Part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform ChosenPart = LevelSectorList[Random.Range(0, LevelSectorList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(ChosenPart, lastEndPostion);
        lastEndPostion = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform LevelPart, Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }
}
