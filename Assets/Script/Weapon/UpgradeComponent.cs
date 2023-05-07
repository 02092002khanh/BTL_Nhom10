using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeComponent : MonoBehaviour
{
    enum Type
    {
        StraightFiring,
        SpreadFring,
        DroneController
    }
    [SerializeField] Type ShootType;
    public int lever;
    [SerializeField] StraightFiring straightFiring;
    [SerializeField] Firing firing;
    [SerializeField] DroneController droneController;
    // Start is called before the first frame update
    void Start()
    {
        if(ShootType == Type.StraightFiring)
        {
            straightFiring = gameObject.GetComponent<StraightFiring>();
        }
        else if(ShootType == Type.SpreadFring)
        {
            firing = gameObject.GetComponent<Firing>();
        }
        else if(ShootType == Type.DroneController)
        {
            droneController = gameObject.GetComponent<DroneController>();
        }
    }
    private void Update() 
    {
        if(ShootType == Type.StraightFiring)
        {
            lever = straightFiring.currentLever;
        }
        else if(ShootType == Type.SpreadFring)
        {
            lever = firing.currentLever;
        }
        else if(ShootType == Type.DroneController)
        {
            lever = droneController.currentLever;
        }
    }

    //upgrade
    public void Upgrade()
    {
        if(ShootType == Type.StraightFiring)
        {
            straightFiring.LeverUp();
        }
        else if(ShootType == Type.SpreadFring)
        {
            firing.LeverUp();
        }
        else if(ShootType == Type.DroneController)
        {
            droneController.LeverUp();
        }
    }
}
