using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;


public abstract class NghiaMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }
    protected virtual void LoadComponent() { }
    protected virtual void ResetValue() { }
    protected void Jobs(List<GameObject> gameObjects, TransformAccessArray transformAccessArray)
    {
        transformAccessArray = new TransformAccessArray(gameObjects.Count);
        for (int i = 0; i < gameObjects.Count; i++)
        {
            transformAccessArray.Add(gameObjects[i].transform);
        }
        ReallyToughParallelJobTransforms reallyToughParallelJobTransforms = new ReallyToughParallelJobTransforms
        {
            deltaTime = Time.deltaTime,
        };
        JobHandle jobHandle = reallyToughParallelJobTransforms.Schedule(transformAccessArray);
        jobHandle.Complete();
        transformAccessArray.Dispose();
    }
    [BurstCompile]
    protected struct ReallyToughParallelJobTransforms : IJobParallelForTransform
    {

        //public NativeArray<float> moveYArray;
        [ReadOnly] public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            //transform.position += new Vector3(0, moveYArray[index] * deltaTime, 0f);
            //if (transform.position.y > 5f)
            //{
            //    moveYArray[index] = -math.abs(moveYArray[index]);
            //}
            //if (transform.position.y < -5f)
            //{
            //    moveYArray[index] = +math.abs(moveYArray[index]);
            //}
        }

    }
}
