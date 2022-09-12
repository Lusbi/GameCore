using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCoreAssetPostprocessor
{
    public abstract string assetPostprocessorName { get; }
    public bool isWork { get; set; }
    
}
