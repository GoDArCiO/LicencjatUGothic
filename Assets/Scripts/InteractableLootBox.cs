using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTInventory;
using DG.Tweening;

public class InteractableLootBox : Interactable
{
    public Character pickerUp;
    public GameObject mainObject;
    public LootBox lootBox;
    public Transform lid;

    public virtual void Open(Character owner)
    {
        References.Instance.pickupItem.InspectLootBox(lootBox);
        lid.DOBlendableRotateBy(new Vector3(0, 0, -100f), 1f, RotateMode.Fast);
    }

    public virtual void Close()
    {
        lid.DOBlendableRotateBy(new Vector3(0, 0, 100f), 1f, RotateMode.Fast);
    }

    public override void Interact(Character character)
    {
        Open(character);
    }

    public override void StopInteracting()
    {
        Close();
    }
}
