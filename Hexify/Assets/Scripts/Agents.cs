using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Agents : Agent
{
    // Start is called before the first frame update
    GridManager g1;
    public override void OnActionReceived(ActionBuffers actions)
    {
        base.OnActionReceived(actions);
    }

    public override void CollectObservations(VectorSensor sensor)
    {

        foreach (var item in g1.grid)
        { 
        sensor.AddObservation(item);
        }
    }
}
