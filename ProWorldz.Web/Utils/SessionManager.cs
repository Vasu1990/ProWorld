using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProWorldz.Web.Utils
{
    public class SessionManager
    {
        private SessionManager(){ }
        private static SessionManager SessionInstance = null;
        public static SessionManager InstanceCreator
        {
            get
            {
                if (SessionInstance == null)
                {
                    SessionInstance = new SessionManager();
                }
                return SessionInstance;
            }
            
        }
        
        public T Get<T>(string key)where T :class{
            T data = null;

            if(System.Web.HttpContext.Current.Session[key] != null) { 
            data = (T)System.Web.HttpContext.Current.Session[key];
            }
            else
            {
                return  data;
            }
            return data;
        }

        public void Set<T>(T input,string key) 
        {
            System.Web.HttpContext.Current.Session[key] = input;
        }
        public void Abandon(string key)
        {
            System.Web.HttpContext.Current.Session.Remove(key) ;
        }
        public void Clear(string key)
        {
            System.Web.HttpContext.Current.Session[key] = null;
        }
    }

    public static class SessionKey
    {
        public static string User = "User";
    }
}