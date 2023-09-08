using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesNodes : MonoBehaviour
{
  private NavMeshAgent navMeshAgent;
  public Transform[] nodes;
  private int activeNode;
  // Start is called before the first frame update
  void Start()
  {
    activeNode = 0;
    navMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
    navMeshAgent.SetDestination(nodes[activeNode].position);
  }

  // Update is called once per frame
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("NodeHit");
    if (other.gameObject.CompareTag("Node"))
    {
      if (activeNode + 1 < nodes.Length)
      {
        activeNode++;
      }
      else
      {
        activeNode = 0;
      }
      navMeshAgent.SetDestination(nodes[activeNode].position);
    }
  }
}
