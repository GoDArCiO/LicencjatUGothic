using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetMousePoint : MonoBehaviour
{
    public Character character;
    public Camera cam;
    public NavMeshAgent navAgent;

    public Vector3 worldPosition;

    public Animator animator;

    private Interactable currentInteractable;
    public float interactDistance;

    void Update()
    {
        Plane plane = new Plane(Vector3.up, 0);

        float distance;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            if (Input.GetMouseButtonDown(0))
            {
                currentInteractable = null;
                navAgent.SetDestination(worldPosition);

                if (Physics.Raycast(ray, out hit))
                {
                    currentInteractable = GameObjectTools.SearchForScript<Interactable>(hit.transform.gameObject, true, true);

                    if (currentInteractable != null)
                    {
                        navAgent.SetDestination(currentInteractable.transform.position);
                    }
                    
                }
            }
        }

        if(currentInteractable != null && Vector3.Distance(transform.position,currentInteractable.transform.position)<interactDistance)
        {
            currentInteractable.Interact(character);
        }

        animator.SetFloat("Blend", navAgent.velocity.magnitude / navAgent.speed);
    }
}
