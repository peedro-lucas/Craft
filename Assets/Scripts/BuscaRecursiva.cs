using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscaRecursiva : MonoBehaviour
{

    private void Update()
    {
        CheckHierarchy(transform);
    }
    private void CheckHierarchy(Transform parent)
    {
        // Itera sobre cada filho do objeto pai atual
        foreach (Transform child in parent)
        {
            // Faz algo com o objeto filho (nesse exemplo, imprime o nome no console)
            Debug.Log(child.name);

            // Verifica recursivamente cada objeto na hierarquia descendente do objeto filho atual
            CheckHierarchy(child);
        }
    }
}
