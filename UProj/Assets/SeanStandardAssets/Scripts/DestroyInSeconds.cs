using UnityEngine;

public class DestroyInSeconds : MonoBehaviour {

    [SerializeField]
    float DestroyDelay = 1f;

	// Use this for initialization
	void Start ()
    {
	    Invoke("DestroyGameObject", DestroyDelay);
	}

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
