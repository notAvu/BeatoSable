using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoteDTO
{
    public int LPB;
    public int num;
    public int direction;
    public int color;
    public int block;
    public int type;
    public List<NoteDTO> notes;
}
public class SongDTO
{
    public string name;
    public int maxBlock;
    public int bpm;
    public int offset;
    public List<NoteDTO> notes;
}
