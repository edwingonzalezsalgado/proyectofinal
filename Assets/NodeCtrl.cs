using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtrl : MonoBehaviour
{
  public float rotateSpeed;
  public float moveSpeed;
  public Transform[] nodes;
  private int activeNode;
  // Start is called before the first frame update
  void Start()
  {
    activeNode = 0;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = Vector3.Lerp(transform.position, nodes[activeNode].position, Time.deltaTime * moveSpeed);
    transform.rotation = Quaternion.Lerp(transform.rotation, nodes[activeNode].rotation, Time.deltaTime * rotateSpeed);
    if (Vector3.Distance(nodes[activeNode].position, transform.position) <= 0.15)
    {
      if (activeNode + 1 < nodes.Length)
      {
        activeNode++;
      }
      else
      {
        activeNode = 0;
      }
    }
  }


}
