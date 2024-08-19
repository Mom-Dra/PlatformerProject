using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform :MonoBehaviour
{
    protected Rigidbody PlatformRb { get; set; }
    protected Collider PlatformCollider { get; set; }

    [Header("DefaultPlatform")]
    [SerializeField]
    Vector3 initPlatformPos;

    public Vector3 InitPlatformPos
    {
        get { return initPlatformPos; }
    }

    protected virtual void Awake()
    {
        PlatformRb = GetComponent<Rigidbody>();
        PlatformCollider = GetComponent<Collider>();
        initPlatformPos = this.transform.position;
    }
    protected abstract IEnumerator GetOnEvent();
}
