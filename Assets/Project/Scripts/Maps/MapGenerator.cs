using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject plane; 
    public List<GameObject> floorPrefabs; 

    public int mapWidth = 10;  
    public int mapHeight = 10;

    private float tileSizeX, tileSizeZ;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        if (plane == null || floorPrefabs.Count == 0)
        {
            Debug.LogError("Chưa gán Plane hoặc Prefab sàn!");
            return;
        }

        float planeWidth = plane.transform.localScale.x * 10f;
        float planeHeight = plane.transform.localScale.z * 10f;
        

        tileSizeX = planeWidth / mapWidth;
        tileSizeZ = planeHeight / mapHeight;

        Vector3 planePosition = plane.transform.position;
        Vector3 startPosition = planePosition - new Vector3(planeWidth / 2, 0, planeHeight / 2);

        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                Vector3 position = startPosition + new Vector3(x * tileSizeX + tileSizeX / 2, 0, z * tileSizeZ + tileSizeZ / 2);
                GameObject tilePrefab = floorPrefabs[Random.Range(0, floorPrefabs.Count)];

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tile.transform.localScale = new Vector3(tileSizeX, 1, tileSizeZ); 
            }
        }

    }
}
