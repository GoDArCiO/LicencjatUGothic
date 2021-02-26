using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public GameObject objectToSpawn;
    public GameObject objectsParent;
    public List<GameObject> asleepObjects = new List<GameObject>();
    public List<GameObject> usedObjects = new List<GameObject>();
    public int startObjectsAmount;

    public void InitPool()
    {
        for (int i = 0; i < startObjectsAmount; i++)
        {
            InitGO();
        }
    }

    private void InitGO()
    {
        GameObject go = Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity, objectsParent.transform);
        asleepObjects.Add(go);
        go.SetActive(false);
    }

    public void ExpandPool()
    {
        InitGO();
    }

    public GameObject Pop()
    {
        if (asleepObjects.Count <= 0)
        {
            ExpandPool();
        }

        GameObject go = asleepObjects[0];
        go.SetActive(true);

        asleepObjects.Remove(go);
        usedObjects.Add(go);

        return go;
    }

    public void Push(GameObject go)
    {
        usedObjects.Remove(go);
        asleepObjects.Add(go);
        go.SetActive(false);
    }

}
