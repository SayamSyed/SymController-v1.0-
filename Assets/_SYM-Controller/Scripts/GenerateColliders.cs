using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GenerateColliders : MonoBehaviour
{
    public void GenerateCollidersNow()
    {
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                child.gameObject.AddComponent<MeshCollider>();
            }
        }
        DestroyImmediate(this);
    }

    public void RemoveComponents()
    {
        Component[] components = GetComponentsInChildren(typeof(MeshCollider), true);

        foreach (var c in components)
        {
            DestroyImmediate(c);
        }
        DestroyImmediate(this);

    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(GenerateColliders))]
class CustomInspector : Editor 
{
    public override void OnInspectorGUI()
    {
        var generateCol = (GenerateColliders)target;
        if(generateCol == null) return;

        if (GUILayout.Button("GenerateColliders"))
        {
            generateCol.GenerateCollidersNow();
        }

        if (GUILayout.Button("RemoveColliders"))
        {
            generateCol.RemoveComponents();
        }

        DrawDefaultInspector();
    }

}
#endif
