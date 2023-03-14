using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    [SerializeField]
    private LayerMask colorLayer; //the layer assigned to the elements you must hit with this instance's gameobject
    private Vector3 lastPosition;
    private const string NON_DIRECTIONAL_TAG = "nonDirectional"; //This is the tag that identifies cubes that don't need to be cut at an specific angle 
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, colorLayer))
        {

            if (!string.IsNullOrEmpty(hit.transform.tag) && hit.transform.CompareTag(NON_DIRECTIONAL_TAG))
            {
                Vector3 posDiff = transform.position - lastPosition;
                if (Vector3.Angle(posDiff, hit.transform.up) > 130 ||
                    Vector3.Angle(posDiff, hit.transform.right) > 130 ||
                    Vector3.Angle(posDiff, -hit.transform.up) > 130 || 
                    Vector3.Angle(posDiff, -hit.transform.right) > 130)
                {
                    CutCube(hit.transform.gameObject);
                }
                else if(Vector3.Angle(posDiff, hit.transform.up) > 130)
                {
                    CutCube(hit.transform.gameObject);
                }
            }
        }
        lastPosition = transform.position;
    }
    private void CutCube(GameObject cube)
    {
        Destroy(cube);
    }
}
