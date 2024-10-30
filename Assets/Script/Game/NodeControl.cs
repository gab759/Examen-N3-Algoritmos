using System.Collections;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public ListaSimple<NodeControl> listAdjacentNodes;

    private void Awake()
    {
        listAdjacentNodes = new ListaSimple<NodeControl>();

    }
    void Update()
    {
        
    }
    public void AddAdjacentNode(NodeControl adjacentNode)
    {
        listAdjacentNodes.InsertAtEnd(adjacentNode);
    }
    public NodeControl GetAdajacentNode()
    {
        int randomIndex = Random.Range(0,listAdjacentNodes.Length);
        return listAdjacentNodes.GetNodeAtPosition(randomIndex);
    }
}
