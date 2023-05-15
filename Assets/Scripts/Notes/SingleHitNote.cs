using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingleHitNote : MonoBehaviour, IHitObject
{
    //TODO Get position and instantiation from lanes 
    public NoteObject noteData;
    public float InstantiationTimestamp;
    public float NoteTimestamp;
    private float TimeSienceInstantiation;
    public SpawnColumn column;
    public RhythmConductor conductor { private get; set; }
    public static Action<NoteHitInfo> noteHit;
    private void Awake()
    {
        //conductor = GameObject.Find("RhythmConductor").GetComponent<RhythmConductor>();
    }
    private void Start()
    {

        var zRotation = UnityEngine.Random.Range(0, 3) * 90;
        transform.Rotate(new Vector3(0, 0, zRotation));

        if (noteData.Column<2)
        {
            gameObject.layer = LayerMask.NameToLayer("RedCube");
            tag = "RedCube";
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("BlueCube");
            tag = "BlueCube";
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    private void Update()
    {
        TimeSienceInstantiation = (float)conductor.GetAudioSourceTime() - InstantiationTimestamp;
        var t = TimeSienceInstantiation *.5f;
        //var aux = InstantiationTimestamp / conductor.secondsPerNote;
        if (t > 1)
        {
            Miss();
        }
        else 
        {
            transform.position = Vector3.Lerp(column.spawnPosition,column.despawnPosition, t); 
        }
    }

    #region vr hit stuff

    public void Hit()
    {
        var hitTime = (float)conductor.GetAudioSourceTime();
        var timeDiff = Mathf.Abs(hitTime - NoteTimestamp);
        NoteHitInfo info = new NoteHitInfo(timeDiff);
        noteHit?.Invoke(info);
        Destroy(gameObject);
    }

    public void Miss()
    {
        noteHit?.Invoke(new NoteHitInfo(10)); //this should be a separate event, If u are reading this I probably didn't make it on time or completely forgot to change it
        Destroy(gameObject);
    }
    #endregion
}
