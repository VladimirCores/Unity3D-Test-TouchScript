using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class GBreaker : MonoBehaviour {

    public Transform TapSpherePrefab;
    public float GPower = 10.0f;

    private Vector3[] _directions = {
                    new Vector3(1, -1, 1),
                    new Vector3(-1, -1, 1),
                    new Vector3(-1, -1, -1),
                    new Vector3(1, -1, -1),
                    new Vector3(1, 1, 1),
                    new Vector3(-1, 1, 1),
                    new Vector3(-1, 1, -1),
                    new Vector3(1, 1, -1)
    };

	// Use this for initialization
	void Start () {
        GetComponent<TapGesture>().StateChanged += Handle_StateChanged;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Handle_StateChanged(object sender, TouchScript.Events.GestureStateChangeEventArgs e)
    {
        if ( e.State == Gesture.GestureState.Recognized )
        {
            if ( transform.localScale.x > 0.05f )
            {
                Color color = new Color( Random.value, Random.value, Random.value );
                for ( int i = 0; i < 8; i++ )
                {
                    var c = Instantiate( TapSpherePrefab ) as Transform;
                    c.parent = transform.parent;
                    c.name = "Cube";
                    c.localScale = 0.5f * transform.localScale;
                    c.position = transform.TransformPoint( c.localScale.x / 10.0f * _directions[i] );
                    c.rigidbody.velocity = GPower * Random.insideUnitSphere;
                    c.renderer.material.color = color;
                }
            }
            Destroy( gameObject );
        }
    }
}
