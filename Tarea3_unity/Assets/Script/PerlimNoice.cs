using UnityEngine;

public class PerlimNoice : MonoBehaviour{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetx = 100f;
    public float offsety = 100f;
    private void Start(){
        offsetx = Random.Range(0f, 9999f);
        offsety = Random.Range(0f, 9999f);
    }
    private void Update(){
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }
    Texture2D GenerateTexture(){
        Texture2D texture = new Texture2D(width, height);
        for(int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }
    Color CalculateColor(int x, int y){
        float xCoord = (float)x / width * scale + offsetx;
        float yCoord = (float)y / height * scale + offsety;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
