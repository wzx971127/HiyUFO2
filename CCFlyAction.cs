using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{
    float acceleration;
    float horizontalSpeed;
    Vector3 direction;
    float time;
    Rigidbody rigidbody;
    // Vector3 old;

    public static CCFlyAction getCCFlyAction()
    {
        CCFlyAction action =  ScriptableObject.CreateInstance<CCFlyAction>();
        return action;
    }

    public override void Start()
    {
        enable = true;
        acceleration = 9.8f;
        time = 0;
        // old = gameObject.transform.position;
        horizontalSpeed = gameObject.GetComponent<DiskData>().getSpeed();
        direction = gameObject.GetComponent<DiskData>().getDirection();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.velocity = horizontalSpeed * direction;
        }
    }

    public override void Update()
    {
        if (gameObject.activeSelf)
        {
            time += Time.deltaTime;
            transform.Translate(Vector3.down * acceleration * time * Time.deltaTime);
            transform.Translate(direction * horizontalSpeed * Time.deltaTime);
            clear();
        }
    }

    public override void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            clear();
        }
    }

    private void clear()
    {
        if (this.transform.position.y < -4)
        {
            this.destroy = true;
            this.enable = false;
            this.callback.SSActionEvent(this);
        }
    }

    public override void stopAction()
    {
        if (rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
        }
    }
}
