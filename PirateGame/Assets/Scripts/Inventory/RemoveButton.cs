using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButton : MonoBehaviour
{
    public Transform invSlot;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(invSlot.position.x + offset.x, invSlot.position.y + offset.y, offset.z);
    }
}
