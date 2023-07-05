using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraMesh : MonoBehaviour
{
    public int dimensaoX, dimensaoY, dimensaoZ;
    public float tamanhoBloco;
    public float seed, inicX, inicZ, maximoY, resolucao;
    public Material[] materiais;

    private GameObject[,,] blocos;

    void Start()
    {
        GeraTerreno();
        GeraBlocos();
    }

    void GeraTerreno()
    {
        blocos = new GameObject[dimensaoX, dimensaoY, dimensaoZ];

        for (int x = 0; x < dimensaoX; x++)
        {
            for (int y = 0; y < dimensaoY; y++)
            {
                for (int z = 0; z < dimensaoZ; z++)
                {
                    float posx = x + inicX * (dimensaoX - 1f);
                    float posy = y;
                    float posz = z + inicZ * (dimensaoZ - 1f);

                    float alturaRelevo = Mathf.PerlinNoise(posx / resolucao, posz / resolucao);
                    
                    // Ajusta a altura do relevo usando o Perlin Noise
                    posy = alturaRelevo * maximoY;

                    // Cria um bloco sólido
                    GameObject bloco = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bloco.transform.position = new Vector3(x * tamanhoBloco, y * tamanhoBloco, z * tamanhoBloco);
                    bloco.transform.localScale = new Vector3(tamanhoBloco, tamanhoBloco, tamanhoBloco);

                    // Define a cor ou textura do bloco
                    Renderer blocoRenderer = bloco.GetComponent<Renderer>();
                    int materialIndex = Random.Range(0, materiais.Length);
                    blocoRenderer.material = materiais[materialIndex];

                    blocos[x, y, z] = bloco;
                }
            }
        }
    }

    void GeraBlocos()
    {
        // Adicione aqui a lógica para interação de quebrar os blocos, se necessário
    }
}
