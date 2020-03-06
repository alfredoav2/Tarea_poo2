using UnityEngine;

public class TerrainGenerator : MonoBehaviour{
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetx = 100f;
    public float offsety = 100f;
    private void Start(){
        offsetx = Random.Range(0f, 9999f);
        offsety = Random.Range(0f, 9999f);
    }
    private void Update() {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        offsetx += Time.deltaTime * 5f;
    }
    TerrainData GenerateTerrain(TerrainData terrainData){
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }
    float[,] GenerateHeights(){
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }
    float CalculateHeight(int x, int y){
        float xCoord = (float)x / width  * scale + offsetx;
        float yCoord = (float)y / height * scale + offsety;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
