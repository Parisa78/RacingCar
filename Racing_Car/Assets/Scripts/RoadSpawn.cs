using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadSpawn : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = 40f;
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(roads => roads.transform.position.z).ToList();
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void moveRoad()
    {
        //var random_number = Random.Range(0, 4);
        //GameObject choosen_road = roads[(int)random_number];
        //roads.Remove(roads.First());
        GameObject choosen_road = roads[0];
        choosen_road.transform.position = new Vector3(choosen_road.transform.position.x, choosen_road.transform.position.y, roads[roads.Count-1].transform.position.z + offset);
        roads.Remove(choosen_road);
        roads.Add(choosen_road);

    }
}
