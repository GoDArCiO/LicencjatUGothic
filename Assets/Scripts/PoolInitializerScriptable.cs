using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pool", menuName = "ScriptableObjects/PoolInitialize", order = 1)]
public class PoolInitializerScriptable : ScriptableObject
{
    public PoolInitObject[] objectsToInitialize;
}
