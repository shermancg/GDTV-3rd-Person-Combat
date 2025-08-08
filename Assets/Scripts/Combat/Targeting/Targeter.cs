using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> targets = new List<Target>();

    void OnTriggerEnter(Collider other)
    {
        // If the other thing we collided with has a Target component, add it to the list
        if (other.TryGetComponent<Target>(out Target target))
        {
            targets.Add(target);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target))
        {
            targets.Remove(target);
        }
    }

}
