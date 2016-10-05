using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform m_head;
	public Vector3 m_positionOfTheHead;

	// Use this for initialization
	void Awake(){
		m_transform = GetComponent<Transform> ();
	}

	void Start () {
		m_head.position = m_positionOfTheHead;
	}
	
	// Update is called once per frame
	void Update () {
		//float headRotationOnYAxis = m_head.eulerAngles.y;
		//m_transform.position = m_head.position - m_positionOfTheHead;



	}

	private Transform m_transform;
}
