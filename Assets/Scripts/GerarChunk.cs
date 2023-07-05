using UnityEngine;

public class GerarChunk : MonoBehaviour
{
    public int chunkSize = 16; // Tamanho do chunk em blocos
    public GameObject blockPrefab; // Prefab do bloco

    private Block[,,] blocks; // Array tridimensional para armazenar as informações dos blocos

    public float perlinScale = 0.1f;
    public float seed; // Semente aleatória para o Perlin Noise

    public static GerarChunk instance;

    private Renderer chunkRenderer;

    private void Start()
    {
        seed = Random.Range(0f, 1000f); // Gera uma semente aleatória

        GenerateBlocks();
    }

    private void Awake()
    {
        if (instance == null) instance = this;

        chunkRenderer = GetComponent<Renderer>();
    }

    private void GenerateBlocks()
    {
        blocks = new Block[chunkSize, chunkSize, chunkSize];

        for (int x = 0; x < chunkSize; x++)
        {
            for (int z = 0; z < chunkSize; z++)
            {
                // Gera a altura usando Perlin Noise com a semente aleatória
                float perlinValue = Mathf.PerlinNoise((transform.position.x + x) * perlinScale + seed, (transform.position.z + z) * perlinScale + seed);
                int height = Mathf.FloorToInt(perlinValue * chunkSize);

                for (int y = 0; y < height; y++)
                {
                    Vector3 blockPosition = new Vector3(x, y, z);
                    blocks[x, y, z] = new Block(blockPosition);

                    // Instancia o Prefab de bloco na posição correta
                    GameObject blockObject = Instantiate(blockPrefab, blockPosition, Quaternion.identity);

                    // Configura o bloco como filho do objeto Chunk
                    //blockObject.transform.parent = transform;
                }
            }
        }
    }

    public void EnableRendering()
    {
            chunkRenderer.enabled = true; // Habilita a renderização do chunk
    }

    public void DisableRendering()
    {
            chunkRenderer.enabled = false; // Desabilita a renderização do chunk
    }

    public class Block
    {
        public Vector3 position;

        public Block(Vector3 position)
        {
            this.position = position;
        }
    }
}
