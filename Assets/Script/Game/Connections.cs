using System.Collections;
using UnityEngine;

public class Connections : MonoBehaviour
{
    public NodeControl FromNode { get; private set; }
    public NodeControl ToNode { get; private set; }
    public float ConnectionStrength { get; private set; } 

    public Connections(NodeControl fromNode, NodeControl toNode, float connectionStrength)
    {
        FromNode = fromNode;
        ToNode = toNode;
        ConnectionStrength = connectionStrength;
    }
}
