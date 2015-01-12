[System.Serializable]
public class Objectives
{
    public bool isDone;
    public string Requirement;

    Objectives()
    {
        isDone = false;
        Requirement = "Objective Display";
    }
}


//Possibly split into 
//TimedObjective
//ResourceObjective
//BonusObjective