using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using stokTakipUygulamasi.Models.Entity;

namespace stokTakipUygulamasi.Roller
{
    public class KullaniciRolleri : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        stokTakipEntities1 rol = new stokTakipEntities1();
        public override string[] GetRolesForUser(string username)
        {
            var kullanici = rol.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == username);
            return new string[] { kullanici.KullaniciRolu };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}