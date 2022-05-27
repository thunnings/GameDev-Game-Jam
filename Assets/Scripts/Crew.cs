using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew
{
    public List<CrewMember> crewMembers = new List<CrewMember>();
    public int startingCrew = 5000;
    public int crewTotal;

    public Crew()
    {
        crewTotal = startingCrew;
        for (int i = 0; i < startingCrew; i++)
        {
            CrewMember newCrew = new CrewMember();
            crewMembers.Add(newCrew);
        }

        foreach(CrewMember member in crewMembers)
        {
            member.RandomAge();
            member.AssignCareer();
        }
    }

    public void CalculateTravelYear(Journey journey)
    {
        CrewMember.Status status;

        for (int i = crewMembers.Count - 1; i >= 0; i--)
        {
            status = crewMembers[i].TravelYear();
            switch (status)
            {
                case CrewMember.Status.alive:
                    break;
                case CrewMember.Status.birth:
                    crewTotal++;
                    journey.totalBirths++;
                    CrewMember newBirth = new CrewMember();
                    crewMembers.Add(newBirth);
                    break;
                case CrewMember.Status.dead:
                    crewMembers.RemoveAt(i);
                    crewTotal--;
                    journey.totalDeaths++;
                    break;
            }
        }
    }

    private int CalculateDeaths()
    {
        int totalDeaths = 0;
        return totalDeaths;
    }

    private int CalculateBirths()
    {
        int totalBirths = 0;
        return totalBirths;
    }

    /*
    [Header("Crew")]
    [Range(0, 5000)]
    public int engineer;

    [Range(0, 5000)]
    public int medical, security, artist, support, command, children;

    [Header("Death Rates")]
    [Range(0, 1)]
    public float engineerDeath;
    [Range(0, 1)] 
    public float medicalDeath, securityDeath, artistDeath, supportDeath, commandDeath, childrenDeath;

    [Header("Birth Rates")]
    [Range(0, 1)]
    public float engineerBirth;
    [Range(0, 1)]
    public float medicalBirth, securityBirth, artistBirth, supportBirth, commandBirth, childrenBirth;

    public int NumberDeaths()
    {
        int totalDeaths = 0;
        int startingEngineer = engineer;
        int startingMedical = medical;
        int startingSecurity = security;
        int startingArtist = artist;
        int startingSupport = support;
        int startingCommand = command;
        int startingChildren = children;

        for (int i = 0; i < startingEngineer; i++)
        {
            if(Random.Range(0,1) < engineerDeath)
            {
                totalDeaths++;
                engineer--;
            }
        }

        for (int i = 0; i < startingMedical; i++)
        {
            if (Random.Range(0, 1) < medicalDeath)
            {
                totalDeaths++;
                medical--;
            }
        }

        for (int i = 0; i < startingSecurity; i++)
        {
            if (Random.Range(0, 1) < securityDeath)
            {
                totalDeaths++;
                security--;
            }
        }

        for (int i = 0; i < startingArtist; i++)
        {
            if (Random.Range(0, 1) < artistDeath)
            {
                totalDeaths++;
                artist--;
            }
        }

        for (int i = 0; i < startingSupport; i++)
        {
            if (Random.Range(0, 1) < supportDeath)
            {
                totalDeaths++;
                support--;
            }
        }

        for (int i = 0; i < startingCommand; i++)
        {
            if (Random.Range(0, 1) < commandDeath)
            {
                totalDeaths++;
                command--;
            }
        }

        for (int i = 0; i < startingChildren; i++)
        {
            if (Random.Range(0, 1) < childrenDeath)
            {
                totalDeaths++;
                children--;
            }
        }

        return totalDeaths;
    }

    public int NumberBirths()
    {
        int totalBirths = 0;
        int startingEngineer = engineer;
        int startingMedical = medical;
        int startingSecurity = security;
        int startingArtist = artist;
        int startingSupport = support;
        int startingCommand = command;
        int startingChildren = children;

        for (int i = 0; i < startingEngineer; i++)
        {
            if (Random.Range(0, 1) < engineerBirth)
            {
                totalBirths++;
                children++;
            }
        }

        for (int i = 0; i < startingMedical; i++)
        {
            if (Random.Range(0, 1) < medicalBirth)
            {
                totalBirths++;
                children++;
            }
        }

        for (int i = 0; i < startingSecurity; i++)
        {
            if (Random.Range(0, 1) < securityBirth)
            {
                totalBirths++;
                children++;
            }
        }

        for (int i = 0; i < startingArtist; i++)
        {
            if (Random.Range(0, 1) < artistBirth)
            {
                totalBirths++;
                children++;
            }
        }

        for (int i = 0; i < startingSupport; i++)
        {
            if (Random.Range(0, 1) < supportBirth)
            {
                totalBirths++;
                children++;
            }
        }

        for (int i = 0; i < startingCommand; i++)
        {
            if (Random.Range(0, 1) < commandBirth)
            {
                totalBirths++;
                children++;
            }
        }

        for (int i = 0; i < startingChildren; i++)
        {
            if (Random.Range(0, 1) < childrenBirth)
            {
                totalBirths++;
                children++;
            }
        }

        return totalBirths;
    }

    public void AssignCareer()
    {

    }*/ //old birth/death code
}
