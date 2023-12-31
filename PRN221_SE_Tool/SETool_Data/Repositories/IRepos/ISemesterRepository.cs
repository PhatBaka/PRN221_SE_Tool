﻿using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.IRepos
{
    public interface ISemesterRepository
    {
        // CREATE
        // READ
        public Task<Semester> GetSemesterByName(string name);
        // UPDATE
        // DELET
    }
}
