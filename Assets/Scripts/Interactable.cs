using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;

    public virtual void Interact(Character character)
    {
        onInteract?.Invoke();
    }

    public virtual void StopInteracting()
    {

    }

}
