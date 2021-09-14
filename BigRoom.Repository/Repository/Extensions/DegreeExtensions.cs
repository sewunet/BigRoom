﻿using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository.Extensions
{
    public static class DegreeExtensions
    {
        public static async Task<bool> IsDoExamAsync(this IRepositoryAsync<Degree> repository, int id, int userId)
        {
            return (await repository.Entities.FirstOrDefaultAsync(a => a.QuizeId == id && a.UserProfileId == userId)) == null ? false : true;
        }
        public static IQueryable<Degree> GetDegrees(this IRepositoryAsync<Degree> repository, int userId)
        {
            return repository.GetAllAsync(a => a.UserProfileId == userId)
                .Include(a => a.Quize.Group);
        }
        public static IQueryable<Degree> GetQuizeDegrees(this IRepositoryAsync<Degree> repository, int quizeId)
        {
            return repository.GetAllAsync(a => a.QuizeId == quizeId).Include(u => u.UserProfile.ApplicationUser);
        }
    }
}
