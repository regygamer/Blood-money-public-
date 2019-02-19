﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{

    public class StateMachine<T>
    {
        public State<T> currentState { get; private set; }
        public T Owner;

        public StateMachine(T _o)
        {
            Owner = _o;
            currentState = null;
        }

        public void ChangeState(State<T> _newstate)
        {
            if (currentState != null)
                currentState.ExitState(Owner);
            currentState = _newstate;
            currentState.EnterState(Owner);
        }

        public void Update()
        {
            if (currentState != null)
                currentState.UpdateState(Owner);
        }
    }

    public abstract class State<T>
    {
        public abstract void EnterState(T _owner); // done once when you enter the state 
        public abstract void ExitState(T _owner); // done once you exit the state
        public abstract void UpdateState(T _owner); // done on update while in state
    }

}