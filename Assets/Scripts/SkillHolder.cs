using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public Skill skill;
    private float _cooldownTime;
    private float _activeTime;

    enum SkillState
    {
        ready,
        active,
        cooldown
    }

    SkillState state = SkillState.ready;

    [SerializeField]
    private KeyCode key;

    private void Update()
    {
        switch (state)
        {
            case SkillState.ready:
                if (Input.GetKeyDown(key))
                {
                    skill.Activate(gameObject);
                    state = SkillState.active;
                    _activeTime = skill.activeTime;
                }
                break;
            case SkillState.active:
                if (_activeTime > 0)
                {
                    _activeTime -= Time.deltaTime;
                }
                else
                {
                    skill.BeginCooldown(gameObject);
                    state = SkillState.cooldown;
                    _cooldownTime = skill.cooldownTime;
                }
                break;
            case SkillState.cooldown:
                if (_cooldownTime > 0)
                {
                    _cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = SkillState.ready;
                }
                break;
        }
    }
}
