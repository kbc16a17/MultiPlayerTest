using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    public Transform Muzzle;
    public GameObject Bullet;
    public float Power;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            CmdFire();
        }

        if (transform.position.y < -25.0f) {
            transform.position = new Vector2(0.0f, 1.0f);
        }
    }

    [Command]
    void CmdFire() {
        var bullet = Instantiate(Bullet, Muzzle.position, Quaternion.identity);
        var rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = Power * transform.forward;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 5.0f);
    }
}
