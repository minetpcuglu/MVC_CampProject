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

        List<Message> GetListStatusTrue();
        List<Message> GetListStatusFalse();
        List<Message> GetListInbox(); //şartlı listeleme
        List<Message> GetListSendbox(); //şartlı listeleme
        //List<Message> GetListTaslakBox();
        void MessageAdd(Message message);//Mesaj eklemek için bir tanım yapıldı

        Message GetById(int id);  //dısarıdan bir ıd alıcak

        void DeleteMessage(Message message); //silme işlemi

        void UpdateMessage(Message message); //güncelleme işlemi 
    }
}
