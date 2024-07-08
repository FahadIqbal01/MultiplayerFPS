using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject playerCamera;

    public void IsLocalPlayer()
    {
        playerMovement.enabled = true;
        playerCamera.SetActive(true);
    }
}
