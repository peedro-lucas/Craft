using UnityEngine;

public class OcclusionCulling : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float chunkRenderDistance = 100f; // Distância máxima para renderizar chunks

    private GerarChunk[] allChunks; // Array que contém todos os scripts GerarChunk

    private void Start()
    {
        allChunks = FindObjectsOfType<GerarChunk>(); // Encontra todos os scripts GerarChunk na cena
    }

    private void Update()
    {
        foreach (var chunk in allChunks)
        {
            // Verifica se o chunk está dentro da distância máxima de renderização
            if (Vector3.Distance(chunk.transform.position, player.position) <= chunkRenderDistance)
            {
                chunk.EnableRendering(); // Habilita a renderização do chunk
            }
            else
            {
                chunk.DisableRendering(); // Desabilita a renderização do chunk se estiver além da distância máxima
            }
        }
    }
}
