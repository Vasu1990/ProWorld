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

    public class ChatMessageList
    {
        [JsonProperty("chatMessage")]
        public string ChatMessage { get; set; }
          [JsonProperty("chatMsgDateTime")]
        public string ChatMsgDateTime { get; set; }
          [JsonProperty("chatterId")]
          public string ChatterId { get; set; }
         [JsonProperty("chatterName")]
          public string ChatterName { get; set; }
    }
    public class ChatModel
    {
          [JsonProperty("chatHostName")]
        public string ChatHostName { get; set; }

          [JsonProperty("chatHostId")]
          public int ChatHostId { get; set; }

          [JsonProperty("chatMsgBoxtext")]
        public string ChatMsgBoxtext { get; set; }

          [JsonProperty("chatMessageList")]
          public List<ChatMessageList> ChatMessageList { get; set; }

          [JsonProperty("chatMessage")]
          public ChatMessageList ChatMessage { get; set; }


          [JsonProperty("chatFriendName")]
        public string ChatFriendName { get; set; }

          [JsonProperty("chatBoxId")]
        public string ChatBoxId { get; set; }

          [JsonProperty("chatFriendImage")]
          public string ChatFriendImage { get; set; }

          [JsonProperty("chatFriendId")]
          public int ChatFriendId { get; set; }



       
    }
}