using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.XmlProvider;
using SIPProvider.CallRecords;
using SIPProvider.SIPCore;
using System.Windows.Forms;

namespace SIPProvider.PhoneBookSaver
{
    /// <summary>
    /// This class save the phone book
    /// Any change in the users it saved internally so , dont save your  change
    /// Data base not add or remove any record only if using AddUser and Deleteuser method
    /// </summary>
    public class PhoneBook
    {
        #region properties
        public Control Container { get; set; }
        private static PhoneBook _instance = null;
        public static PhoneBook Instance
        {
            get
            {
                if (_instance == null) _instance = new PhoneBook();
                return _instance;
            }
        }
        /// <summary>
        /// Occurs when user removed from data base
        /// </summary>
        public event ItemRemoved OnUserRemoved;
        /// <summary>
        /// Occurs when user added to data base
        /// </summary>
        public event ItemAdded OnUserAdded;
        /// <summary>
        /// Occurs when user Edited and changed
        /// </summary>
        public event DataChanged OnUserEdited;
        /// <summary>
        /// Conain the last error
        /// </summary>
        public Exception LastException { get;private set; }
        private List<PhoneUser> Users;
        /// <summary>
        /// The max user id
        /// </summary>
        private long MaxUserId;
        XmlFile XmlFile;
        #endregion

        private PhoneBook()
        {
            XmlFile = new XmlFile("PhoneBook.dat", true );
            XmlFile.RootName = "PhoneBook";
        }
        
        #region private methods
       
        private void LoadRecords()
        {
            Users = new List<PhoneUser>();
            List<string> sections = XmlFile.GetSectionNames();
            foreach (string section in sections)
            {
                PhoneUser user = GetRecord(section);
                if (user == null) continue;
                user.Id = long.Parse(section);
                if (user.Id > MaxUserId) MaxUserId = user.Id;
                RegisterUserEvents(user);
                Users.Add(user);
            }
        //    Users.Sort(PhoneUserComparer.Instance);
        }

        void user_OnDataChanging(object sender, DataChangeEventArgs e)//This method check if the update valid
        {
            try
            {
                PhoneUser user = (PhoneUser)sender;
                if (user == null) return;
                if (e.DataName == PhoneUserDataNames.UserName)
                    if (!CanAddUserUser(e.NewValue + "", user.UserNumber)) e.CancelEdit = true;
                if (e.DataName == PhoneUserDataNames.UserNumber)
                    if (!CanAddUserUser(user.UserName, e.NewValue + "")) e.CancelEdit = true;
            }
            catch { }
        }

        private void user_OnDataChanged(object sender, DataChangeEventArgs e)
        {
            try
            {
                PhoneUser user = (PhoneUser)sender;
                if (user == null) return;
                RiseEvent(OnUserEdited, sender, e);
                string section = user.Id + "";
                string newValue = e.NewValue is DateTime ? ((DateTime)e.NewValue).ToBinary() + "" : e.NewValue + "";
                XmlFile.SetValue(section, e.DataName, newValue);
                XmlFile.SaveDocument();
            }
            catch { }
        }



        private PhoneUser GetRecord(string section)
        {
            try
            {
                Dictionary<string, string> data = XmlFile.GetEntryValues(section);
                PhoneUser user = new PhoneUser();
                user.UserName = data[PhoneUserDataNames.UserName];
                user.UserNumber = data[PhoneUserDataNames.UserNumber];
                user.UserAddress = data[PhoneUserDataNames.UserAddress];
                user.UserEmail = data[PhoneUserDataNames.UserEmail];
                user.RegisterTime = DateTime.FromBinary(long.Parse(data[PhoneUserDataNames.RegisterTime])); 
                return user;
            }
            catch { return null; }
        }


        /// <summary>
        /// Save this user to xml file
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool SaveUser(PhoneUser user)
        {
            try
            {
                string section = user.Id + "";
                XmlFile.SetValue(section, PhoneUserDataNames.UserName, user.UserName);
                XmlFile.SetValue(section, PhoneUserDataNames.UserNumber, user.UserNumber);
                XmlFile.SetValue(section, PhoneUserDataNames.UserAddress, user.UserAddress);
                XmlFile.SetValue(section, PhoneUserDataNames.UserEmail, user.UserEmail);
                XmlFile.SetValue(section, PhoneUserDataNames.RegisterTime, user.RegisterTime.ToBinary() + "");
                return true;
            }
            catch (Exception ex) { LastException = ex; return false; }
        }

        private void RegisterUserEvents(PhoneUser user)
        {
            user.OnDataChanged += new SIPProvider.SIPCore.DataChanged(user_OnDataChanged);
            user.OnDataChanging += new DataChanged(user_OnDataChanging);
        }

        private void RiseEvent(Delegate deleg, params object[] param)
        {
            if (deleg == null) return;
            if (Container != null && Container.InvokeRequired) Container.Invoke(deleg, param);
            else deleg.DynamicInvoke(param);
        }
        #endregion


        #region public methods

        public bool IsExistsUser(string userName, string userNumber)
        {
            try
            {
                PhoneUser user = PhoneBook.Instance.SearchOneUser(u => (u.UserName.ToLower() == userName.ToLower()) &&
                                                      (u.UserNumber.ToLower() == userNumber.ToLower())
                    );
                return user != null;
            }
            catch { return false; }
        }
        /// <summary>
        /// User can add if not repeated and userName not empty and userNumber not empty
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        public bool CanAddUserUser(string userName, string userNumber)
        {
            try
            {
                if (userName == "" || userNumber == "") return false;
                else return !IsExistsUser(userName, userNumber);
            }
            catch { return false; }
        }

        public PhoneUser GetUser(string userName, string userNumber)
        {
            try
            {
                PhoneUser user = PhoneBook.Instance.SearchOneUser(u => (u.UserName.ToLower() == userName.ToLower()) &&
                                                      (u.UserNumber.ToLower() == userNumber.ToLower())
                    );
                return user;
            }
            catch { return null; }
        }

        /// <summary>
        /// Get the first user has this userNumber
        /// </summary>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        public PhoneUser GetUser(string userNumber)
        {
            try
            {
                PhoneUser user = PhoneBook.Instance.SearchOneUser(u => u.UserNumber.ToLower() == userNumber.ToLower());
                return user;
            }
            catch { return null; }
        }

        /// <summary>
        /// Search users and get userName if user found or return the user number
        /// </summary>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        public string GetUserNameOrNumber(string userNumber)
        {
            try
            {
                PhoneUser user = GetUser(userNumber);
                if (user == null) return userNumber;
                else return user.UserName;
            }
            catch { return ""; }
        }

        public PhoneUser GetUserById(long userId)
        {
            try
            {
                return SearchOneUser(u => u.Id == userId);//load from memory if it loaded
            }
            catch (Exception ex) { LastException = ex; return null; }
        }

        /// <summary>
        /// If the item found return
        /// Return null if the add user failied
        /// </summary>
        /// <param name="user"></param>
        public PhoneUser AddUser(string UserName, string UserNumber, DateTime RegisterTime, string UserAddress, string UserEmail)
        {
            try
            {
                if (IsExistsUser(UserName, UserNumber))
                {
                    LastException = new Exception("Can not add this user becouse of Repeated data");
                    return null;
                }
                if (UserName == "" || UserNumber=="")
                {
                    LastException = new Exception("Can not add this user becouse UserName or UserNumber empty.");
                    return null;
                }
                PhoneUser user = new PhoneUser(UserName, UserNumber, RegisterTime, UserAddress, UserEmail);
                user.Id = ++MaxUserId;
                if (SaveUser(user))
                {
                    RegisterUserEvents(user);
                    if (Users != null)
                        Users.Add(user);
                    RiseEvent(OnUserAdded, user);
                  
                    XmlFile.SaveDocument();
                    return user;
                }
                else return null;
            }
            catch (Exception ex) { LastException = ex; return null; }
        }


        public bool DeleteUser(long userId)
        {
            try
            {
                PhoneUser user = GetUserById(userId);
                if(user==null)return false;
                if (Users != null)//remove user from memory
                     Users.Remove(user);
                if (!XmlFile.RemoveSection(userId + "")) return false;
                else
                {
                    RiseEvent(OnUserRemoved, user);
                    XmlFile.SaveDocument();
                    return true;
                }
            }
            catch (Exception ex) { LastException = ex; return false; }
        }

        public void DeleteUser(long[] userIds)
        {
            try
            {
                foreach (long userId in userIds)
                {
                    PhoneUser user = GetUserById(userId);
                    if (user == null) continue;
                    if (Users != null)//remove user from memory
                        Users.Remove(user);
                    if (XmlFile.RemoveSection(userId + ""))
                        RiseEvent(OnUserRemoved, user);
                }
                XmlFile.SaveDocument();
            }
            catch (Exception ex) { LastException = ex;  }
        }

        public List<PhoneUser> SearchUsers(Predicate<PhoneUser> match)
        {
            try
            {
                if (Users == null) LoadRecords();
                return Users.FindAll(match);
            }
            catch { return new List<PhoneUser>(); }
        }

        public PhoneUser SearchOneUser(Predicate<PhoneUser> match)
        {
            try
            {
                if (Users == null) LoadRecords();
                return Users.Find(match);
            }
            catch { return null; }
        }

        public List<PhoneUser> GetUsers()
        {
            try
            {
                if (Users == null) LoadRecords();
                return new List<PhoneUser>(Users);
            }
            catch { return new List<PhoneUser>(); }
        }
        /// <summary>
        /// Save a back up copy
        /// </summary>
        /// <param name="backUpFile"></param>
        public void SaveBackUp(string backUpFile)
        {
            try { XmlFile.SaveBackUp(backUpFile); }
            catch { }
        }
        #endregion
       
    }
}
