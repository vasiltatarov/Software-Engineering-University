﻿using System;
using Skeleton.Models.Contracts;

public class Dummy : ITarget
{
    private int experience;

    public Dummy(int health, int experience)
    {
        this.Health = health;
        this.experience = experience;
    }

    public int Health { get; private set; }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.Health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

    public bool IsDead() => this.Health <= 0;
}
