using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : Interactable
{
    public Character pickerUp;
    public GameObject mainObject;

    public virtual void PickUp(Character owner)
    {
        PickupableSpawnManager.Instance.DespawnPickupable(mainObject);
    }

    public override void Interact(Character character)
    {
        PickUp(character);
    }
}
