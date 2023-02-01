using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _object;
        public MessageManager(IMessageDal p)
        {
            _object = p;
        }
        public void AddMessage(Message p)
        {
            _object.Insert(p);
        }

        public void DeleteMessage(Message p)
        {
            _object.Delete(p);
        }

        public Message GetById(int id)
        {
            return _object.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(bool status, string p)
        {
            return _object.List(x => x.ReceiverMail == p && x.Status==status);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _object.List(x => x.SenderMail == p);
        }

        public void UpdateMessage(Message p)
        {
            _object.Update(p);
        }
    }
}
