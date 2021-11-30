using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    private float scale = 20f;
    private float offsetX = 0;
    private float offsetY = 0;

    private static int widght = 512;
    private static int height = 512;
    private float depth = 2f;

   // float[,] noisemap = new float[widght, height];
    // Start is called before the first frame update
    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain (TerrainData terrainData)
	{
        terrainData.heightmapResolution = widght + 1;
        terrainData.size = new Vector3(widght, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
	}
    // Update is called once per frame
   
    float [,] GenerateHeights()
	{
        float[,] heights = new float[widght, height];
        for(int i=0; i<widght; i++)
		{
            for(int j=0; j<height; j++)
			{
                heights[i, j] = CalculateHeights(i, j);
			}
		}

        return heights;
	}

    float CalculateHeights(int x, int y)
    {
        float xCord = (float)x / widght * scale + offsetX;
        float yCord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
