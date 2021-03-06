﻿using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.DataAccessObject.DTO;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using static System.Collections.Specialized.BitVector32;

namespace SAMTool.BusinessServices.Services
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _userRepository;
       
        Guid AppID=Guid.Parse(ConfigurationManager.AppSettings["ApplicationID"]);
        string key = System.Web.Configuration.WebConfigurationManager.AppSettings["cryptography"];
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
          
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = null;
            try
            {
                userList = _userRepository.GetAllUsers(null);
                userList = userList == null ? null : userList.Select(c => { c.Password = null; return c; }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userList;
        }

        public User GetUserDetailsByID(string id)
        {
            List<User> UserList = null;
         
            try
            {
                UserList = _userRepository.GetAllUsers(null);
                UserList = UserList!=null?UserList.Where(j => j.ID==Guid.Parse(id)).ToList():null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserList[0];
        }

        public object InsertUser(User userObj)
        {
            object result = null;
            try
            {
                if (!string.IsNullOrEmpty(userObj.Password))
                {
                    userObj.Password = Encrypt(userObj.Password);
                }
                result = _userRepository.InsertUser(userObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public object UpdateUser(User userObj)
        {
            object result = null;
            try
            {
                if (!string.IsNullOrEmpty(userObj.Password))
                {
                    userObj.Password = Encrypt(userObj.Password);
                }
                result = _userRepository.UpdateUser(userObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public User CheckUserCredentials(User user)
        {
            User _user = null;
            List<User> userList = null;

            try
            {
               userList = _userRepository.GetAllUsers(AppID);
               userList = userList == null ? null : userList.Where(us => us.Active==true && us.LoginName.ToLower() == user.LoginName.ToLower() && us.Password == Encrypt(user.Password)).Select(c => { c.Password = null; return c; }).ToList();
              _user = userList == null || userList.Count==0 ? null : userList[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _user;

        }

        private string Encrypt(string plainText)
        {
            //AES 128bit Cross Platform (Java and C#) Encryption Compatibility

            string encryptedText = "";
            try
            {

                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var keyBytes = new byte[16];
                var secretKeyBytes = Encoding.UTF8.GetBytes(key);
                Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
                encryptedText = Convert.ToBase64String(new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    KeySize = 128,
                    BlockSize = 128,
                    Key = keyBytes,
                    IV = keyBytes
                }.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return encryptedText;
        }

        public Permission GetSecurityCode(string LoginName, string ProjectObject)
        {
            Permission _permission = new Permission()
            {
                Name = ProjectObject,
                AccessCode = _userRepository.GetObjectAccess(LoginName, ProjectObject, AppID),
                SubPermissionList = _userRepository.GetSubObjectAccess(LoginName, ProjectObject, AppID)
            };
            return _permission;
        }
        public List<Permission> GetAllAccess(string LoginName)
        {
            List<Permission> permissionList = _userRepository.GetAllAccess(LoginName, AppID);

            return permissionList = permissionList != null ? (from permission in permissionList.Where(x => x.ParentID == Guid.Empty).ToList() select new Permission
            {
                Name = permission.Name,
                AccessCode = permission.AccessCode,
                SubPermissionList = permissionList.Where(x => x.ParentID == permission.ID).ToList().Count>0?(from subPermission in permissionList.Where(x => x.ParentID == permission.ID).ToList() select new SubPermission
                {
                    Name = subPermission.Name.ToString(),
                    AccessCode = subPermission.AccessCode.ToString()
                }).ToList():new List<SubPermission>(),
            }).ToList() :new List<Permission>();
        }
        public object DeleteUser(User userObj)
        {
            object result = null;
            try
            {
                result = _userRepository.DeleteUser(userObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}