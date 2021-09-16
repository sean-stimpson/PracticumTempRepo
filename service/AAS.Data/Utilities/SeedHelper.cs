using AutoMapper;
using AAS.Data.DTOs;
using AAS.Data.Models;
using System;
using System.Linq;
using AAS.Data;
using AAS.Data.Utilities;

namespace Aas.Data.Utilities
{
    public static class SeedHelper
    {
        public static Group GetRandomGroup(AasDbContext database)
        {
            return database.Groups.OrderBy(_ => Guid.NewGuid()).First();
        }

        public static Group CreateValidNewGroup(AasDbContext database, string name = "")
        {
            return new Group()
            {
                Name = name.Length == 0 ? RandomFactory.GetAlphanumericString(8) : name,
                IsActive = RandomFactory.GetBoolean()
            };
        }

        public static GroupDto CreateValidNewGroupDto(AasDbContext database, IMapper mapper, string name = "")
        {
            var group = CreateValidNewGroup(database, name);

            return mapper.Map<GroupDto>(group);
        }

        public static Project CreateValidNewProject(AasDbContext database, Group group = null)
        {
            return new Project()
            {
                Name = RandomFactory.GetCodeName(),
                Group = group ?? GetRandomGroup(database)
            };
        }
    }
}
