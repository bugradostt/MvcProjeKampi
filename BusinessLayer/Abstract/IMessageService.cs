using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(bool status, string p);
        List<Message> GetListSendbox(string p);
        void AddMessage(Message p);
        void DeleteMessage(Message p);
        void UpdateMessage(Message p);
        Message GetById(int id);
    }
}
