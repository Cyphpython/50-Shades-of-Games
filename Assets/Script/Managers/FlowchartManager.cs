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

    public static void SetBoolVar(string conditionName)
    {
        if (string.IsNullOrEmpty(conditionName)) { Debug.LogError("variable is null or empty !!"); return; }

        if (_flowchart == null) { Debug.LogError("No Flowchart Assigned !!"); return; }

        Fungus.BooleanVariable BoolVar = _flowchart.GetVariable<Fungus.BooleanVariable>(conditionName);

        if (BoolVar != null) { BoolVar.Value = true; }

        else { Debug.LogError($"Flowchart found but variable '{conditionName}' does not exist"); }

    }

    public static Fungus.BooleanVariable GetBoolVar(string VarName)
    {
        if (string.IsNullOrEmpty(VarName)) { Debug.LogError("variable is null or empty !!"); return null; }
        if (_flowchart == null) { Debug.LogError("No Flowchart Assigned !!"); return null; }
        Fungus.BooleanVariable var = _flowchart.GetVariable<Fungus.BooleanVariable>(VarName);
        if (var != null) { return var; }
        else { Debug.LogError($"Flowchart found but variable '{VarName}' does not exist"); return null; }
    }
   
    //optional funct
    public static void SetFlowchart(Flowchart flowchart) { _flowchart = flowchart; }
}
