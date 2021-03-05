using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DTInventory;

public class GetMousePoint : MonoBehaviour
{
    public Character character;
    public Camera cam;
    public NavMeshAgent navAgent;

    public Collider terrain;

    public Vector3 worldPosition;

    public Animator animator;

    private Interactable currentInteractable;
    public float interactDistance;
    public bool interacting;


    public Transform sword;
    public Transform shield;
    public EquipmentPanel equipmentPanelMelee;
    public EquipmentPanel equipmentPanelShield;

    void Update()
    {

        if (equipmentPanelMelee.equipedItem!=null)
        {
            sword.gameObject.SetActive(true);
        }
        else
        {
            sword.gameObject.SetActive(false);
        }

        if (equipmentPanelShield.equipedItem != null)
        {
            shield.gameObject.SetActive(true);
        }
        else
        {
            shield.gameObject.SetActive(false);
        }

        HandleNavigation();

        HandleInventory();

        HandleAnimator();
    }

    private void HandleNavigation()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit,1000))
        {
            worldPosition = hit.point;
            if (Input.GetMouseButtonDown(0) && !interacting)
            {
                currentInteractable = null;
                navAgent.SetDestination(hit.point);
                Debug.Log(transform.position + "x" + hit.point);

                currentInteractable = GameObjectTools.SearchForScript<Interactable>(hit.transform.gameObject, true, true);

                if (currentInteractable != null)
                {
                    navAgent.SetDestination(currentInteractable.transform.position);
                }


            }
        }
    }

    private void HandleAnimator()
    {
        animator.SetFloat("Velocity", navAgent.velocity.magnitude / navAgent.speed);
    }

    private void HandleInventory()
    {
        if (currentInteractable != null && Vector3.Distance(transform.position, currentInteractable.transform.position) < interactDistance && !interacting)
        {
            currentInteractable.Interact(character);
            interacting = true;
        }

        if (interacting && Input.GetKeyDown(KeyCode.I))
        {
            if(currentInteractable != null)
            {
                currentInteractable.StopInteracting();
            }
            
            currentInteractable = null;
            interacting = false;
            return;
        }

        if (!interacting && Input.GetKeyDown(KeyCode.I))
        {
            interacting = true;
            return;
        }
    }
}
