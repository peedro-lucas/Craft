using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin : MonoBehaviour
{
    public int TamX;
    public int TamZ;

    private GameObject[,] Terreno;

    public GameObject Bloco;

    public int x;
    public int z;

    public int alturaMaxima;

    public int resolucao;


    private void Start()
    {
        Terreno = new GameObject[TamX, TamZ];

        for (x = 0; x < TamX; x++)
        {
            for (z = 0; z < TamZ; z++)
            {
                Terreno[x,z] = Instantiate(Bloco, new Vector3(x * Bloco.transform.localScale.x, 0, z * Bloco.transform.localScale.z), Quaternion.identity);
            }
        }
        Elevacao(0);
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
                altura =alturaMaxima *  Mathf.PerlinNoise((x + seed) / Mathf.Sqrt(TamX * resolucao), (z + seed) / Mathf.Sqrt(TamZ * resolucao)); ;
                Terreno[x, z].transform.Translate(0, Mathf.Floor(altura) * Bloco.transform.localScale.y, 0);
            }
        }
    }

