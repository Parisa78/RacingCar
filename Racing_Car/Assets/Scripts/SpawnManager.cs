using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawn roads_pawn;
    // Start is called before the first frame update
    void Start()
    {
        roads_pawn=GetComponent<RoadSpawn>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTriggerEnter()
    {
        roads_pawn.moveRoad();
    }
}
