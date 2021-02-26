using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameObjectPoolMultiObject: MonoBehaviour
{
    public GameObject poolObjectsParent;

    public PoolInitializerScriptable initStuff;

    private List<GameObject> asleepObjects = new List<GameObject>();
    private List<GameObject> usedObjects = new List<GameObject>();
    

    public void InitPool()
    {
        foreach(PoolInitObject p in initStuff.objectsToInitialize)
        {
            for(int i = 0; i< p.amount; i++)
            {
                InitGO(p.objectToInitialize);
            }
        }
    }

    private void InitGO(GameObject g)
    {
        GameObject go = Instantiate(g, Vector3.zero, Quaternion.identity, poolObjectsParent.transform);
        asleepObjects.Add(go);
        go.SetActive(false);
    }

    public void ExpandPool(GameObject g)
    {
        InitGO(g);
    }

    public GameObject Pop(GameObject g)
    {
        GameObject go = asleepObjects.Find(x => g.name+"(Clone)" == x.name);

        if (go == null)
        {
            ExpandPool(g);

            go = asleepObjects.Find(x => g.name + "(Clone)" == x.name);
        }

        go.SetActive(true);

        asleepObjects.Remove(go);
        usedObjects.Add(go);

        return go;
    }

    public void Push(GameObject go)
    {
        if (!asleepObjects.Contains(go))
        {
            go.transform.parent = poolObjectsParent.transform;
            usedObjects.Remove(go);
            asleepObjects.Add(go);
            go.SetActive(false);
        }

    }

}
