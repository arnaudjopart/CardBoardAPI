using UnityEngine;
using System.Collections;

public class MoveManager : MonoBehaviour {

	public Transform m_body;
	public LayerMask m_layerMask;
	public float m_lengthOfRay;
	public RectTransform m_directionIndicator;

	public float m_speedOfMove;


	// Use this for initialization

	void Awake(){
		m_transform = GetComponent<Transform> ();
		m_directionIndicator.GetComponent<MoveEvent> ().MoveEventHandler+=ManageMove;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		while (m_GvrHead == null) {
		
			m_GvrHead = FindHead ();
		
		}
		m_GvrHead.target = m_transform.parent;
		m_GvrHead.trackPosition = true;

		Ray floorRay = new Ray (m_transform.position, m_transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (floorRay, out hit, m_lengthOfRay, m_layerMask)) {
			if (hit.collider.gameObject.layer == 8) {
				m_directionIndicator.position =  hit.point;
				print (hit.collider.gameObject.name);
				Vector3 projectedPositionOfGround = new Vector3 (m_transform.position.x, m_transform.position.z,0.1f );
				distanceBetweenPlayerAndDirection = m_directionIndicator.position - projectedPositionOfGround;

					Quaternion rotation = Quaternion.LookRotation (Vector3.down,distanceBetweenPlayerAndDirection );
				m_directionIndicator.rotation = rotation;
				//m_directionIndicator.eulerAngles.Set (m_directionIndicator.eulerAngles.x, 0, -90);
			}
			else {

				// Replace here with Dissapear function

				m_directionIndicator.position = new Vector3 (0, -5, 0);
			}


		} else {
			m_directionIndicator.position = new Vector3 (0, -5, 0);
		}

		if (m_isMoving) 
		{
			Vector3 customForward = Vector3.Normalize (distanceBetweenPlayerAndDirection);
			print (customForward);
			m_body.position+= customForward * m_speedOfMove * Time.deltaTime;
		}

		//Debug.DrawRay (transform.position, transform.position + transform.forward*m_lengthOfRay);
	}

	public void ManageMove(bool _bool)
	{
		m_isMoving = _bool;
	}

	private GvrHead FindHead(){
	
		return GetComponent<GvrHead> () == null ? null : GetComponent<GvrHead> ();
	}
	private GvrHead m_GvrHead;
	private bool m_isMoving;
	private Transform m_transform;
	private Vector3 distanceBetweenPlayerAndDirection;


}
