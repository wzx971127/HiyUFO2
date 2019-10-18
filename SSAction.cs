using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSAction : ScriptableObject {
    public bool enable = false;
    public bool destroy = false;

    public GameObject gameObject { set; get; }
    public Transform transform { set; get; }
    public ISSActionCallback callback { set; get; }

    protected SSAction() { }

    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }

    public void reset()
    {
        enable = false;
        destroy = false;
        gameObject = null;
        transform = null;
        callback = null;
    }

    internal void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }
}
