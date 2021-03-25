using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectThower : MonoBehaviour
{
    public string triggerName;
    public Rigidbody[] objects;
    public float throwImpulse;

    private Rigidbody heldObject;

    // Update is called once per frame
    void Update()
    {
        // Check if the hand's trigger has been pressed
        if(Input.GetButtonDown(triggerName))
        {
            // Choose a random object to spawn
            Rigidbody randomObject = objects[Random.Range(0, objects.Length)];

            // Spawn that object
            heldObject = Instantiate(randomObject, transform.position, transform.rotation, transform);
            
            // Attach the object to the hand
            heldObject.useGravity = false;
            heldObject.isKinematic = true;
        }

        // Check if the hand's trigger has been released
        if (Input.GetButtonUp(triggerName))
        {
            // Dettach the object from the hand
            heldObject.transform.SetParent(null);
            heldObject.useGravity = true;
            heldObject.isKinematic = false;

            // Apply a force to the object to throw it
            heldObject.AddForce(transform.forward * throwImpulse);
        }
    }
}