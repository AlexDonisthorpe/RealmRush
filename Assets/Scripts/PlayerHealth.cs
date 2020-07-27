using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    [SerializeField] TMP_Text healthText;

    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerHealth--;
    }
}
