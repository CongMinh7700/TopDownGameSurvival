using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShootableObject",menuName ="SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    [SerializeField] public ObjectType objectType;
    [SerializeField] public double hpMax;
    [SerializeField] public string objectName = " ";

}
