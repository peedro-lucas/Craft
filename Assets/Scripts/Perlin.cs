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


    public GameObject player;


    public List<GameObject> chunksFora,chunksGame = new List<GameObject>();


    public GameObject prefabChunk;

    public Camera cam;

    public GameObject objetoPai;

    public List<GameObject> MapaInteiro = new List<GameObject>();


    public static Perlin instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    private void Start()
    {
        seed = Random.Range(0, 120);

        auxAlturaMaxima = alturaMaxima;
        Terreno = new GameObject[TamX, TamZ];

        for (x = 0; x < TamX; x++)
        {
            for (z = 0; z < TamZ; z++)
            {
                GameObject terreno = Terreno[x,z] = Instantiate(Bloco, new Vector3(x * Bloco.transform.localScale.x, 0, z * Bloco.transform.localScale.z), Quaternion.identity);
                MapaInteiro.Add(terreno);
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
}

