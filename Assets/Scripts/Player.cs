using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;
    public bool firstPlayer;
    [Space]
    public GameObject CanonLauncher;
    public GameObject DummyWeapon;
    public Transform ShootPoint;
    private void Start()
    {

    }

    public void Initialize(int _id, string _username, bool _firstPlayer)
    {
        id = _id;
        username = _username;
        firstPlayer = _firstPlayer;
    }

    /// <summary>Processes player input and moves the player.</summary>
    public void FixedUpdate()
    {
       
    }

    public void RotateTowards(Vector3 _RequiredVelocity)
    {
        Vector3 _mirroredRequiredVelocity = _RequiredVelocity;
        if (!firstPlayer)
        {
            _mirroredRequiredVelocity = MirrorConverter.MirrorVector3(_RequiredVelocity, Axis.yAxis);
        }
        CanonLauncher.transform.rotation = Quaternion.LookRotation(_mirroredRequiredVelocity);
        ServerSend.CanonRotation(id, _RequiredVelocity);
    }

    public void CanonShoot(Vector3 _ThrowVelocity,int weaponIndex)
    {
        Vector3 _mirrorThrowVelocity = _ThrowVelocity;
        if (!firstPlayer)
        {
            _mirrorThrowVelocity = MirrorConverter.MirrorVector3(_mirrorThrowVelocity, Axis.yAxis);
        }
        Rigidbody obj = Instantiate(DummyWeapon, ShootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        obj.velocity = _mirrorThrowVelocity;
        ServerSend.CanonShoot(id,_ThrowVelocity, weaponIndex);
    }

    public void TakeDamage(float _damage)
    {

    }

}
