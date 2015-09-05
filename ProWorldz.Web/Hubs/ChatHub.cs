using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using ProWorldz.Web.Utils;
using ProWorldz.BL.BusinessModel;

namespace ProWorldz.Web
{
      
    public class ChatHub : Hub
    {

        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();


        public void SendChatMessage(ChatModel model)
        {
            string userName = Context.User.Identity.Name;
            
           
          //  Clients.Client(Context.ConnectionId).addChatMessage(userName, model.ChatMsgBoxtext);

            foreach (var connectionId in _connections.GetConnections(model.ChatFriendName))
            {
                int hostId = model.ChatHostId;

                model.ChatHostName = model.ChatFriendName;
                model.ChatFriendName = Context.User.Identity.Name;
                model.ChatHostId = model.ChatFriendId;
                model.ChatFriendId = hostId;

                Clients.Client(connectionId).appendChatBoxOnFriend(model);
                //Clients.Client(connectionId).addChatMessage(model.ChatFriendName, model.ChatMsgBoxtext);
            }
        }

        public bool CheckIfAlreadyConnected(string who)
        {
            string connections = null;
            foreach (var connectionId in _connections.GetConnections(who))
            {
                connections = connectionId;
            }
            bool isConnected = connections != null;
            return isConnected;
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;

            _connections.Remove(userName, Context.ConnectionId);
            //set online flag to false
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string userName = Context.User.Identity.Name;

           // if (!_connections.GetConnections(userName).Contains(Context.ConnectionId))
            if (!CheckIfAlreadyConnected(userName))
            {
                _connections.Add(userName, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

        public void CreateAuth()
        {
            string userName =  Context.User.Identity.Name;
            //HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            if (!CheckIfAlreadyConnected(userName))
            {
                _connections.Add(userName, Context.ConnectionId);
                base.OnConnected();
            }
        }

       
    }

  
}