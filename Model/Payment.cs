using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Model
{
    internal class Payment
    {
        //        a.paymentId;
        //b.paymentDate;
        //c.paymentAmount;
        //d.client; // Represents the client associated with the payment
        public int PaymentId { get; set; }
        public DateTime  PaymentDate { get; set; }
        public float PaymentAmount { get; set; }
        public string ClientName { get; set; }
        public Payment()
        {

        }
        public Payment(int paymentid,DateTime paymentdate,float paymentamount,string client)
        {
            PaymentId=paymentid;
            PaymentDate=paymentdate;
            PaymentAmount=paymentamount;
            ClientName=client;
        }
        public override string ToString()
        {
            return $"PaymentId: {PaymentId}, PaymentDate: {PaymentDate}, PaymentAmount: {PaymentAmount}, Client: {ClientName}";
        }
    }
}
