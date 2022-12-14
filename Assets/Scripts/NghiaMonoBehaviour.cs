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
    protected void Jobs(List<GameObject> gameObjects, TransformAccessArray transformAccessArray, float3 dir, bool test)
    {
        if (test)
        {
            transformAccessArray = new TransformAccessArray(gameObjects.Count);
            NativeArray<float3> positionArray = new NativeArray<float3>(gameObjects.Count, Allocator.TempJob);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                positionArray[i] = gameObjects[i].transform.position;
                transformAccessArray.Add(gameObjects[i].transform);
            }
            ReallyToughParallelJobTransforms reallyToughParallelJobTransforms = new ReallyToughParallelJobTransforms
            {
                deltaTime = Time.deltaTime,
                positionArray = positionArray,
                vector = dir,
            };
            JobHandle jobHandle = reallyToughParallelJobTransforms.Schedule(transformAccessArray);
            jobHandle.Complete();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].transform.position = positionArray[i];
            }
            positionArray.Dispose();
            transformAccessArray.Dispose();
        }
        else
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].transform.position += (Vector3)dir * Time.deltaTime;
            }
        }
    }
    protected void JobsMove(NativeArray<float> moveYArray)
    {

    }
    [BurstCompile]
    protected struct ReallyToughParallelJobTransforms : IJobParallelForTransform
    {
        public NativeArray<float3> positionArray;
        //public NativeArray<float> moveYArray;
        [ReadOnly] public float deltaTime;
        public float3 vector;

        public void Execute(int index, TransformAccess transform)
        {
            positionArray[index] += vector * deltaTime;
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
