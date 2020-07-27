using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth--;
    }
}
