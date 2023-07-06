using UnityEngine;
using System.Collections.Generic;

public class DesativarObjetosForaDaArea : MonoBehaviour
{
    public Vector3 centro = Vector3.zero;
    public Vector3 tamanho = Vector3.one;
    private List<GameObject> objetosNaArea = new List<GameObject>();

    public Camera camera; // Referência à câmera que não deve ser desativada

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(centro, tamanho);
    }

    private void Start()
    {
        AtualizarObjetosNaArea();
    }

    private void Update()
    {
        DesativarObjetosForaArea();
    }

    private void AtualizarObjetosNaArea()
    {
        objetosNaArea.Clear();
        Collider[] colliders = Physics.OverlapBox(centro, tamanho / 2f);
        foreach (Collider collider in colliders)
        {
            objetosNaArea.Add(collider.gameObject);
        }
    }

    private void DesativarObjetosForaArea()
    {
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj != camera.gameObject && !objetosNaArea.Contains(obj))
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
            }
        }
    }
}
