using UnityEngine;

public class OcclusionCulling : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public float chunkRenderDistance = 100f; // Dist�ncia m�xima para renderizar chunks

    private GerarChunk[] allChunks; // Array que cont�m todos os scripts GerarChunk

    private void Start()
    {
        allChunks = FindObjectsOfType<GerarChunk>(); // Encontra todos os scripts GerarChunk na cena
    }

    private void Update()
    {
        foreach (var chunk in allChunks)
        {
            // Verifica se o chunk est� dentro da dist�ncia m�xima de renderiza��o
            if (Vector3.Distance(chunk.transform.position, player.position) <= chunkRenderDistance)
            {
                chunk.EnableRendering(); // Habilita a renderiza��o do chunk
            }
            else
            {
                chunk.DisableRendering(); // Desabilita a renderiza��o do chunk se estiver al�m da dist�ncia m�xima
            }
        }
    }
}
