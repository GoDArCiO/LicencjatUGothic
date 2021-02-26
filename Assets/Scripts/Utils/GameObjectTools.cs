using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTools : MonoBehaviour
{
    public static T SearchForScript<T>(GameObject gameObject, bool searchInParent = false, bool searchInChildren = false) where T : MonoBehaviour
    {
        T script = null;

        script = gameObject.GetComponent<T>();

        if (!script && searchInParent)
        {
            script = gameObject.GetComponentInParent<T>();
        }
        if (!script && searchInChildren)
        {
            script = gameObject.GetComponentInChildren<T>();
        }

        return script;
    }

}
