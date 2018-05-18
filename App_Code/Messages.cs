﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
    public string SenderID { get; set; }
    public string RecipientID { get; set; }
    public string UserClass { get; set;}
    public string UserType { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public bool IsContinues { get; set; }
    public bool IsReadByMe { get; set; }
    public string MessageType { get; set; }

    DBconnection db = new DBconnection();

    public Messages() 
    {

    }

    public Messages(string _SenderID, string _RecipientID, string _Subject, string _Content, string _MessageType, string _UserClass, string _UserType) //private message.
    {
        SenderID = _SenderID;
        RecipientID = _RecipientID;
        Subject = _Subject;
        Content = _Content;
        MessageType = _MessageType;
        UserClass = _UserClass;
        UserType = _UserType;
    }


    public Messages(string _SenderID, string _UserClass, string _UserType, string _Subject, string _Content, string _MessageType)  //koleltive message.
    {
        SenderID = _SenderID;
        UserClass = _UserClass;
        UserType = _UserType; 
        Subject = _Subject;
        Content = _Content;
        MessageType = _MessageType;
    }

    public int SendPrivateMessage(Messages m)
    {
        return db.SendPrivateMessage(m.SenderID, m.RecipientID, m.Subject, m.Content);
    }

    public int SendKolektiveMessage(Messages m)
    {
        return db.SendKolektiveMessage(m.SenderID, m.UserClass, m.UserType, m.Subject, m.Content);
    }
}