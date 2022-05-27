using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember
{   public enum Sex { male, female };
    public enum Status { alive, dead, birth };


    [SerializeField]
    private int age = 0;

    int maxAge = 120;
    Sex sex;

    [Range(0, .1f)]
    float birthRate = 0.015f;

    [Range(0, .1f)]
    float deathRate = 0.0025f;
    

    public CrewMember()
    {
        if (Random.Range(0, 2) > 0.5)
            sex = Sex.male;
        else
            sex = Sex.female;
    }

    public void RandomAge()
    {
        age = (int)(RandomGaussian() * maxAge);
    }

    public void AssignCareer()
    {
        //code to randomize what career the crewmember will be
    }

    public Status TravelYear()
    {
        age++;

        if (age > maxAge)
            return Status.dead;

        if (Random.Range(0f, 1f) < (deathRate + age/1000))
            return Status.dead;
        else if (sex == Sex.male)
            return Status.alive;
        else if (Random.Range(0f, 1f) < birthRate && age > 13)
            return Status.birth;
        else
            return Status.alive;
    }

    public void NewBirth()
    {
        age = 0;
    }

    public int GetAge()
    {
        return age;
    }

    public Sex GetSex()
    {
        return sex;
    }

    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}

