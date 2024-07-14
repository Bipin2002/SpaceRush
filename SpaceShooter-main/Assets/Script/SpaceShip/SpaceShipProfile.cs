using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SpaceShipsProfile/Profile")]
public class SpaceShipProfile : ScriptableObject
{
    public string shipName;
    public GameObject shipModel; 
    public float movementSpeed;
    public float turnSpeed;
    public float upthrust;
}
