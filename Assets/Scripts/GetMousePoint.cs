using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetMousePoint : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent navAgent;

    public Vector3 worldPosition;

    public Animator animator;

    void Update()
    {
        Plane plane = new Plane(Vector3.up, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            if (Input.GetMouseButtonDown(0)) navAgent.SetDestination(worldPosition);
        }
        Debug.Log(navAgent.velocity.magnitude/navAgent.speed);

        animator.SetFloat("Blend", navAgent.velocity.magnitude / navAgent.speed);
    }
}
