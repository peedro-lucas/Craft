using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin : MonoBehaviour
{
    public int TamX;
    public int TamZ;
    public int TamY;

    private GameObject[,] Terreno;

    public GameObject Bloco;

    public int x;
    public int z;

    public int alturaMaxima;

    public int auxAlturaMaxima;

    public int resolucao;

    public int seed;

    private int paredeX, paredeY;

    public GameObject player;



    public List<GameObject> chunksFora,chunksGame = new List<GameObject>();

    public int areaChunks;

    public GameObject prefabChunk;


    public Vector3 lookRadius;

    public List<GameObject> objetosNaArea = new List<GameObject>();

    public Camera cam;


    private void Start()
    {
        paredeX = 0;
        paredeY = 0;
        seed = Random.Range(0, 199);

        auxAlturaMaxima = alturaMaxima;
        Terreno = new GameObject[TamX, TamZ];

        for (x = 0; x < TamX; x++)
        {
            for (z = 0; z < TamZ; z++)
            {
                Terreno[x,z] = Instantiate(Bloco, new Vector3(x * Bloco.transform.localScale.x, 0, z * Bloco.transform.localScale.z), Quaternion.identity);
            }
        }
        
        Elevacao(seed);
    }

    private void Update()
    {

    }

    void Elevacao(float seed)
    {
        float altura;
        for (x = 0; x < TamX; x++)

            for (z = 0; z < TamZ; z++)
            {
                altura = alturaMaxima * Mathf.PerlinNoise((x + seed) / Mathf.Sqrt(TamX * resolucao), (z + seed) / Mathf.Sqrt(TamZ * resolucao)); ;
                Terreno[x, z].transform.Translate(0, Mathf.Floor(altura) * Bloco.transform.localScale.y, 0);
            }
    }

    void VerificaChunks()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(player.transform.position , lookRadius);
    }
}

