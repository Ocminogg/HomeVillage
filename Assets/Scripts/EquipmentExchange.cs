using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentExchange : MonoBehaviour
{
    [SerializeField] private MeshFilter[] peoples;
    [SerializeField] private Mesh[] tools;
    // Start is called before the first frame update
    
    public void Exchage()
    {
        Debug.Log("Try exchange!");

        for(int i = 0; i < peoples.Length; i++)
        {
            var mesh = GetRandomTools();
            if (mesh == null)
            {
                Debug.LogError("peoples - prefab == null");
                return;
            }
            peoples[i].mesh = mesh;
        }    
    }
    
    private Mesh GetRandomTools()
    {
        if (tools.Length == 0)
        {
            Debug.LogError("tools - prefabs is empty!");
            return null;
        }

        int index = Random.Range(0, tools.Length);
        return tools[index];
    }
}
