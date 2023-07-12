using System.Collections.Generic;
using UnityEngine;

public class DesativarObjetosForaDaArea : MonoBehaviour
{
    public Vector3 tamanho = Vector3.one;
    public List<GameObject> objetosNaArea = new List<GameObject>();

    public GameObject player;

    public static DesativarObjetosForaDaArea instance;

    private MeshRenderer colliderMesh;


    private void Awake()
    {
        if (instance == null) instance = this;
    }


    private void Start()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(player.transform.position, tamanho);
    }

    private void Update()
    {
        
        objetosNaArea.Clear();
        Collider[] colliders = Physics.OverlapBox(player.transform.position, tamanho / 2f);
        foreach (Collider collider in colliders)
        {
            colliderMesh = collider.gameObject.GetComponent<MeshRenderer>();
            objetosNaArea.Add(collider.gameObject);

            if (objetosNaArea.Contains(collider.gameObject)) {
                colliderMesh.enabled = true;
            }

            
        }

        
    }

}
