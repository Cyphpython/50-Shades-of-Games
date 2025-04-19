using UnityEngine;
using Fungus;

public static class FlowchartManager 
{
    private static Flowchart _flowchart;

    public static void UseItemBlock(string BlockName)
    {
        if (string.IsNullOrEmpty(BlockName)) { Debug.LogError("UseBlock is null or empty !!"); return; }

        if (_flowchart == null) { Debug.LogError("No Flowchart Assigned !!"); return; }

        if (_flowchart.HasBlock(BlockName)) { _flowchart?.ExecuteBlock(BlockName); }

        else Debug.LogError($"Flowchart found but block '{BlockName}' does not exist.");
    }
    //optional funct
    public static void SetFlowchart(Flowchart flowchart) { _flowchart = flowchart; }
}
