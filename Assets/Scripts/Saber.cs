using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Saber : MonoBehaviour
{
    //[SerializeField]
    //private LayerMask colorLayer; //the layer assigned to the elements you must hit with this instance's gameobject
    [SerializeField]
    private string targetTag;
    private Vector3 lastPosition;

    //private const string NON_DIRECTIONAL_TAG = "nonDirectional"; //This is the tag that identifies cubes that don't need to be cut at an specific angle 
    private void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position+transform.forward, transform.up, Color.red, .25f);
        //Physics.BoxCast(transform.position, new Vector3(.05f, .7f, 1), transform.forward, out hit);
        //Physics.Raycast(transform.position, transform.forward, out hit, 1f)
        if (Physics.BoxCast(transform.position, new Vector3(.05f, .35f, 1), transform.forward, out hit))
        {
            //Debug.Log("colorLayer "+LayerMask.LayerToName(/*colorLayer*/.value));
            Debug.Log(hit.transform.tag);

            if (!string.IsNullOrEmpty(hit.transform.tag) && hit.transform.CompareTag(targetTag) /*&& hit.transform.gameObject.layer.Equals(colorLayer)*/)/*&& hit.transform.CompareTag(NON_DIRECTIONAL_TAG)*/
            {
                Vector3 posDiff = transform.position - lastPosition;
                if (Vector3.Angle(posDiff, hit.transform.up) > 130)
                {
                    FailCubeCut(hit.transform.gameObject);
                }
                else /*if(Vector3.Angle(posDiff, hit.transform.up) > 130)*/
                {
                    CutCube(hit.transform.gameObject);
                }
            }
        }
        lastPosition = transform.position;
    }

    private void CutCube(GameObject cube)
    {
        cube.GetComponent<IHitObject>().Hit();
    }
    private void FailCubeCut(GameObject cube)
    {
        cube.GetComponent<IHitObject>().Miss();
    }
}
