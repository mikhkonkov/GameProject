using UnityEngine;using System.Collections;
public class decal01 : MonoBehaviour
{ 
	public GameObject decalPrefab;  // Use this for initialization
	void Start ()
	{
	}   // Update is called once per frame 
	void Update ()
	{
		RaycastHit hit;
		if (Physics.Raycast (camera.ScreenPointToRay (Input.mousePosition), out hit)) {
			if (hit.collider.tag == "DecalOn" && Input.GetMouseButtonDown (0))         // Call the decal generation method. 
				DecalGen (hit.point, hit.normal, hit.collider);
		}
	}  
	// Decal generation method.
	GameObject DecalGen (Vector3 p, Vector3 n, Collider c)
	{  // Container for our decal instance 
		GameObject decalInst;     // Instantiate the actual decal
		decalInst = (GameObject)Instantiate (decalPrefab, p, Quaternion.FromToRotation (Vector3.up, n));   
		// Acquire necessary information 
		MeshFilter mf = decalInst.GetComponent (typeof(MeshFilter)) as MeshFilter;
		Mesh m = mf.mesh;   
		// Create a new array to store the decal mesh vertices 
		Vector3[] verts = m.vertices;     
		// Loop through all the delcal mesh vertices, convert them in local space 
		// and check if any of them exceeds the hit collider bounds.
		for (int i = 0; i < verts.Length; i++) {
			verts [i] = decalInst.transform.TransformPoint (verts [i]);   
			if (verts [i].x > c.bounds.max.x) {
				verts [i].x = c.bounds.max.x;
			}   
			if (verts [i].x < c.bounds.min.x) {
				verts [i].x = c.bounds.min.x;
			}    
			if (verts [i].y > c.bounds.max.y) {
				verts [i].y = c.bounds.max.y;
			}   
			if (verts [i].y < c.bounds.min.y) {
				verts [i].y = c.bounds.min.y;
			}   
			if (verts [i].z > c.bounds.max.z) {
				verts [i].z = c.bounds.max.z;
			}   
			if (verts [i].z < c.bounds.min.z) {
				verts [i].z = c.bounds.min.z;
			}   
			// Convert the vertices back in world space and assign them bacl to the decal mesh. 
			verts [i] = decalInst.transform.InverseTransformPoint (verts [i]);
			m.vertices = verts;
		}  
		return decalInst;
	}
}