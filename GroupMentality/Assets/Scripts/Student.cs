using UnityEngine;
using UnityEditor;

public abstract class Student : MonoBehaviour
{
    public float speed; // how fast the student moves
    public float randomness; // how random their movements are
    public float minDistanceToFollow;    // how far away from Benno it has to be before starts moving

public abstract void Move();
//public abstract void 
    

}
