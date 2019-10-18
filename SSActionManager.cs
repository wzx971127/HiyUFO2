using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour {
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    private List<SSAction> waitingAdd = new List<SSAction>();
    private List<int> waitingDelete = new List<int>();
    protected bool flag = true;

    protected void Update()
    {
        foreach (SSAction action in waitingAdd)
        {
            actions[action.GetInstanceID()] = action;
        }
        waitingAdd.Clear();

        foreach (KeyValuePair<int, SSAction> i in actions)
        {
            SSAction value = i.Value;
            if (value.destroy)
            {
                waitingDelete.Add(value.GetInstanceID());
            }
            else if (value.enable && flag)
            {
                value.Update();
            }
            else if (value.enable && flag == false)
            {
                value.FixedUpdate();
            }
        }

        foreach (int i in waitingDelete)
        {
            SSAction ac = actions[i];
            actions.Remove(i);
            DestroyObject(ac);
        }
    }

    public void runAction(GameObject gameObject, SSAction action, ISSActionCallback manager)
    {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }

}