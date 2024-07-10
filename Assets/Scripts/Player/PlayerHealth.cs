using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;

    [Header("UI")]
    [SerializeField] Text healthText;

    [PunRPC]
    public void TakeDamage(int _damage)
    {
        health -= _damage;
        healthText.text = health.ToString();

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
