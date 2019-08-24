using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenuResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    public bool GetFullyVisible()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        foreach (Plane plane in planes)
        {
            foreach (Vector3 vertice in this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.vertices)
            {
                if (plane.GetDistanceToPoint(transform.TransformPoint(vertice)) < 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
