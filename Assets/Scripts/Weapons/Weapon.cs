using Photon.Pun;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] int damage;
    [SerializeField] float fireRate;
    [SerializeField] float nextFire;

    [Header("VFX")]
    [SerializeField] GameObject hitVfx;

    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && nextFire <= 0)
        {
            nextFire = 1 / fireRate;

            Fire();
        }
    }

    void Fire()
    {
        Ray ray = new Ray(origin: _camera.transform.position, direction: _camera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(origin: ray.origin, direction: ray.direction, hitInfo: out hit, maxDistance: 100f))
        {
            PhotonNetwork.Instantiate(prefabName: hitVfx.name, position: hit.point, rotation: Quaternion.identity);

            if (hit.transform.gameObject.GetComponent<PlayerHealth>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC(methodName: "TakeDamage", target: RpcTarget.All, parameters: damage);
            }
        }
    }

}
