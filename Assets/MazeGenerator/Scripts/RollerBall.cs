using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour {

	public GameObject ViewCamera = null;
	private Rigidbody mRigidBody = null;

    public float YOffset = 0.5f;
    public float XOffset = 0.5f;

	public int Threshold = -2;

	public float xmove;
	public float ymove;

	public GameObject dot;
    public OSCReciever oscReciever;
	
	void Start () 
	{
		mRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () 
	{
		if (oscReciever.FloatY >0.1f || oscReciever.FloatX >0.1f)
		{
			ymove = (oscReciever.FloatY - YOffset) * Threshold;
			xmove = (oscReciever.FloatX - XOffset) * Threshold;
        }
		else
		{
            ymove = 0;
            xmove = 0;
        }

		mRigidBody.AddForce(Vector3.forward * ymove);
		mRigidBody.AddForce(Vector3.right * xmove);

		dot.transform.position = transform.position + new Vector3 (xmove, 0, ymove);

		if (ViewCamera != null)
		{
			Vector3 direction = (Vector3.up * 2 + Vector3.back) * 2;
			RaycastHit hit;
			Debug.DrawLine(transform.position, transform.position + direction, Color.red);
			if (Physics.Linecast(transform.position, transform.position + direction, out hit))
			{
				ViewCamera.transform.position = hit.point;
			}
			else
			{
				ViewCamera.transform.position = transform.position + direction;
			}
			ViewCamera.transform.LookAt(transform.position);
		}
	

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals ("Coin"))
		{
			Destroy(other.gameObject);
			Debug.Log("You Win");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
