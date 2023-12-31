﻿using SETool_Data.DAOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.Repos
{
    public class TeacherProjectRepository : ITeacherProjectRepository
    {
        public Task<IEnumerable<TeacherProject>> GetTeacherProjectByTeacherId(int id) => TeacherProjectDAO.Instance.GetTeacherProjectsByTeacherId(id);
    }
}
