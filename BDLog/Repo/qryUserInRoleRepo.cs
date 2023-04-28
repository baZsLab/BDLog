using BDELog.Contexts;
using BDELog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BDELog.Repo
{
    public class qryUserInRoleRepo
    {
        protected BD_Context _context;

        public qryUserInRoleRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryUserInRole> GetQryUserInRole()
        {
            var qryList = (from ur in _context.BUserroles
                           join us in _context.BUsers on ur.Userid equals us.Id
                           join ro in _context.BRoles on ur.Roleid equals ro.Id

                           //group ro by us into g
                           //select new
                           //{
                           //    UserName = g.Key.Username,
                           //    RoleName = g.Select(u => u.Name)
                           //}).ToList()
                           //.Select(x=> new { x.UserName, RoleName = string.Join(", ", x.RoleName) });



            select new qryUserInRole()
            {
                UserId = us.Id,
                UserName = us.Username,
                RoleId = ro.Id,
                RoleName = ro.Name

            }).ToList();


            return qryList;
        }
    }
}
