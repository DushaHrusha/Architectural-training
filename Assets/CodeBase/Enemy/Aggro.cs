using System.Linq;
using System;
using Architectural_training.Assets.CodeBase.Enemy;
using UnityEngine;
using System.Collections;

public class Aggro : MonoBehaviour
{
    public TriggerObserver triggerObserver;
    public AgentMoveToPlayer Follow;
    public float coolDown;

    private  Coroutine _aggrCoroutine;
    private bool _hasAgrroTarget;
    void Start()
    {
        triggerObserver.TriggerEnter += TriggerEnter;
        triggerObserver.TriggerExit += TriggerExit;

        SwitchFollowOff();
    }

    private void OnDestroy()
    {
      triggerObserver.TriggerEnter -= TriggerEnter;
      triggerObserver.TriggerExit -= TriggerExit;
    }
    private void TriggerEnter(Collider collider)
    {
        if(!_hasAgrroTarget)
        {
            _hasAgrroTarget = true;
            StopAggroCoroutine();
            SwitchFollowOn();
        }
    }

    private void TriggerExit(Collider collider)
    {
        if(_hasAgrroTarget)
        {
            _hasAgrroTarget = false; 
            _aggrCoroutine = StartCoroutine(SwitchFollowAfterCooldown());
        }
    }

    public IEnumerator SwitchFollowAfterCooldown()
    {
        yield return new WaitForSeconds(coolDown);
        SwitchFollowOff();
    } 

    private void StopAggroCoroutine()
    {
        if (_aggrCoroutine != null)
        {
            StopCoroutine(_aggrCoroutine);
            _aggrCoroutine = null;
        }
    }

    private void SwitchFollowOn() => Follow.enabled = true;

    private void SwitchFollowOff() => Follow.enabled = false;
}
