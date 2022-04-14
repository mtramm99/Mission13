﻿using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void SaveBowler(Bowler b);
        public void DeleteBowler(Bowler b);
        public void CreateBowler(Bowler b);
    }
}
