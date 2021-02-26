using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableSpawnManager : MonoBehaviourSingleton<PickupableSpawnManager>
{

    [SerializeField] private GameObjectPoolMultiObject weaponPool;

    private void Start()
    {
        weaponPool.InitPool();
    }

    public GameObject SpawnPickupable(GameObject prefab)
    {
        GameObject go = weaponPool.Pop(prefab);

        return go;
    }

    public void DespawnPickupable(GameObject g)
    {
        weaponPool.Push(g);
    }

}
