using UnityEngine;
using UnityEngine.Networking;

public class DisableUnlocalPlayerBehaviour : NetworkBehaviour {
    [SerializeField]
    private Behaviour[] behaviours;

    public void Start() {
        if (!isLocalPlayer) {
            foreach (var behaviour in behaviours) {
                behaviour.enabled = false;
            }
        }
    }
}