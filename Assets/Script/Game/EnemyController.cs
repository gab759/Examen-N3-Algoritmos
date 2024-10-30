using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 positionToMove;
    public float speedMove;
    public float maxEnergy = 10f;
    public float currentEnergy;
    public float restDuration = 5f;
    public float restTimer = 0f;
    public bool isResting = false;
    private float currentConnectionWeight;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }
    private void Update()
    {
        if (isResting)
        {
            RestEnergy();
        }
        else
        {
            MoveEnemy();
        }
    }
    private void RestEnergy()
    {
        restTimer += Time.deltaTime;

        if (restTimer >= restDuration)
        {
            currentEnergy = maxEnergy;
            isResting = false;
            restTimer = 0f;
        }
    }

    private void MoveEnemy()
    {
        if (currentEnergy > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);
            Debug.Log($"Peso de conexión actual: {currentConnectionWeight}");

            currentEnergy -= currentConnectionWeight * Time.deltaTime;

            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                isResting = true;
            }
        }
    }

    public void SetNewPosition(Vector2 newPosition, float connectionWeight)
    {
        positionToMove = newPosition;
        currentConnectionWeight = connectionWeight;

        isResting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nodo")
        {
            NodeControl nextNode = collision.GetComponent<NodeControl>().GetAdajacentNode();
            Connections connection = collision.GetComponent<Connections>();

            if (connection != null)
            {
                float connectionWeight = connection.ConnectionStrength; 

                SetNewPosition(nextNode.transform.position, connectionWeight);
            }
        }
    }
}
